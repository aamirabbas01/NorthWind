class Supplier extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            supplierData: []        };
        this.handleTextChange = this.handleTextChange.bind(this);
    }
    handleTextChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        const supplierData = this.state.supplierData;
        const newState = {
            supplierData: { ...supplierData, [name]: value }
        };

        this.setState(newState);
    }
    componentDidUpdate() {
        if (this.state.supplierData.length == 0 && this.props.PageMode=='Edit') {
            this.setState({ supplierData: this.props.supplier });
        }
    }
    render() {
        const supplier = this.state.supplierData;
        let content = (supplier.length == 0 && this.props.PageMode == 'Edit') ? <img src="/Images/loading.gif" /> : '';
        return (
            <div className="row">
                {content}
                <div className="col-md-4">
                    {(() => {
                        if (this.props.PageMode == 'Edit') {
                            return (
                                <input type="hidden" value={supplier.id} />
                            )
                        }
                        return null;
                    })()}
                    <div className="form-group">
                        <label htmlFor="CompanyName" className="control-label">Company Name</label>
                        <input type="text" name="companyName" value={supplier.companyName} onChange={this.handleTextChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="ContactName" className="control-label">Contact Name</label>
                        <input type="text" name="contactName" value={supplier.contactName} onChange={this.handleTextChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="ContactTitle" className="control-label">Contact Title</label>
                        <input type="text" name="contactTitle" value={supplier.contactTitle} onChange={this.handleTextChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="City" className="control-label">City</label>
                        <input type="text" name="city" value={supplier.city} onChange={this.handleTextChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Country" className="control-label">Country</label>
                        <input type="text" name="country" value={supplier.country} onChange={this.handleTextChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Phone" className="control-label">Phone</label>
                        <input type="text" name="phone" value={supplier.phone} onChange={this.handleTextChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Fax" className="control-label">Fax</label>
                        <input type="text" name="fax" value={supplier.fax} onChange={this.handleTextChange} className="form-control" />
                    </div>
                    <div className="form-group mt-2">
                        <button onClick={() => this.props.onSave(supplier)} value="Save" className="btn btn-primary"><i className="bi bi-pencil-square"></i>&nbsp;Save</button>
                        &nbsp;&nbsp;<a href="/Suppliers" className="btn btn-primary">Back to List</a>
                    </div>
                </div>
            </div>

        );
    }
}

