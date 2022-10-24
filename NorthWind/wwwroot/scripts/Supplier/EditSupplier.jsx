/// <reference path="supplier.jsx" />

class EditSupplier extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            supplier: [],
            mode: this.props.mode
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        
    }

    componentDidMount() {
        fetch(this.props.url)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({ supplier: result });
                }
            )
    }

    handleSubmit = supplier => {

        fetch(this.props.url, {

            // Adding method type
            method: "PUT",

            // Adding body or contents to send
            body: JSON.stringify(supplier),

            // Adding headers to the request
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
            .then(res => res.json())

        window.location.href = '/Suppliers/';

    }

    render() {
        const supplier = this.state.supplier;
        return (
            <Supplier supplier={supplier} onSave={this.handleSubmit} PageMode={this.state.mode}/>
        );
    }
}

