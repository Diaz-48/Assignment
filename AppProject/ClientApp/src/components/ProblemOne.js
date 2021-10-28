import React, { Component } from 'react';

export class ProblemOne extends Component {

    constructor(props) {
        super(props);
        this.state = {
            results: []
        };
    }

    componentDidMount() {
        this.getFirstEndpoint();
    }

    async getFirstEndpoint() {
        const response = await fetch('api/money/getendpointone');
        const data = await response.json();
        this.setState({ results: data });
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
