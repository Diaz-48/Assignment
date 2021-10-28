import React, { Component } from 'react';

export class ProblemTwo extends Component {

    constructor(props) {
        super(props);
        this.state = {
            results: []
        };
    }

    componentDidMount() {
        this.getSecondEndpoint();
    }

    async getSecondEndpoint() {
        const response = await fetch('api/money/getendpointtwo');
        const data = await response.json();
        this.setState({ results: data });
        console.log(this.state.results);
    }

    render() {

        return (
            <div>
                <p>
                    {this.state.results}
                </p>
            </div>
        );
    }

    
}
