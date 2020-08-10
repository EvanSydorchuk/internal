import React, { Component } from "react";
import CandidatesDataService from "../services/candidates.service";
import Pagination from "@material-ui/lab/Pagination";
import "./styles/mainstyles.css";

export default class CandidatesList extends Component {
  constructor(props) {
    super(props);
    this.onChangeSearch = this.onChangeSearch.bind(this);
    this.retrieveCandidates = this.retrieveCandidates.bind(this);
    this.handlePageChange = this.handlePageChange.bind(this);
    this.handlePageSizeChange = this.handlePageSizeChange.bind(this);

    this.state = {
      candidates: [],
      currentCandidate: null,
      currentIndex: -1,
      searchFilter: "",
      page: 1,
      count: 0,
      pageSize: 20,
    };

    this.pageSizes = [20, 40, 60];
  }

  componentDidMount() {
    this.retrieveCandidates();
  }

  onChangeSearch(e) {
    const searchFilter = e.target.value;

    this.setState({
      searchFilter: searchFilter,
    });
  }

  getRequestParams(searchFilter, page, pageSize) {
    let params = {};

    if (searchFilter) {
      params["searchFilter"] = searchFilter;
    }
    console.log(searchFilter);

    if (page) {
      params["pageNumber"] = page;
    }

    if (pageSize) {
      params["pageSize"] = pageSize;
    }

    return params;
  }

  retrieveCandidates() {
    const { searchFilter, page, pageSize } = this.state;
    const params = this.getRequestParams(searchFilter, page, pageSize);

    CandidatesDataService.getAll(params)
      .then((response) => {
        this.setState({
          candidates: response.data.data,
          count: response.data.pageViewModel.totalPages,
        });
      })
      .catch((e) => {
        console.log(e);
      });
  }

  handlePageChange(event, value) {
    this.setState(
      {
        page: value,
      },
      () => {
        this.retrieveCandidates();
      }
    );
  }

  handlePageSizeChange(event) {
    this.setState(
      {
        pageSize: event.target.value,
        page: 1,
      },
      () => {
        this.retrieveCandidates();
      }
    );
  }

  render() {
    const {
      candidates,
      page,
      count,
      pageSize,
    } = this.state;

    return (
      <div className="list row">
        <div className="input-group">
          <input
            value={this.state.searchFilter}
            onChange={this.onChangeSearch}
            type="text"
            className="form-control"
            placeholder="Search"
          />
          <div className="input-group-append">
            <button
              className="btn btn-outline-secondary"
              type="button"
              onClick={this.retrieveCandidates}
            >
              Search
            </button>
          </div>
        </div>
        <div>
          <h4>Candidates List</h4>

          <div className="mt-3">
            {"Items per Page: "}
            <select onChange={this.handlePageSizeChange} value={pageSize}>
              {this.pageSizes.map((size) => (
                <option key={size} value={size}>
                  {size}
                </option>
              ))}
            </select>

            <Pagination
              className="my-3"
              count={count}
              page={page}
              siblingCount={1}
              boundaryCount={1}
              variant="outlined"
              shape="rounded"
              onChange={this.handlePageChange}
            />
          </div>
          <table>
            <thead>
              <tr>
                <th>Name</th>
                <th>Surname</th>
                <th>Loaction</th>
                <th>Competence</th>
                <th>Competence Level</th>
                <th>Contacts</th>
              </tr>
            </thead>
            <tbody>
              {candidates &&
                candidates.map((candidate, index) => (
                  <tr key={index}>
                    <td>{candidate.name} </td>
                    <td>{candidate.surname} </td>
                    <td>{candidate.location} </td>
                    <td>{candidate.competence} </td>
                    <td>{candidate.competenceLevel}</td>
                    <td className="contact-info">
                      {candidate.contacts.map((x) => (
                        <div>
                          {x.name} : {x.value}
                          <br></br>
                        </div>
                      ))}
                    </td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}
