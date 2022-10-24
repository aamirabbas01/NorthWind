class SupplierList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { suppliers: [] };
        this.UpdateSupplier = this.UpdateSupplier.bind(this);
        this.DeleteSupplier = this.DeleteSupplier.bind(this);
        this.DetailSupplier = this.DetailSupplier.bind(this);
    }
    SuppliersGet = () => {
        fetch("/api/Suppliers")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({ suppliers: result });
                }
            )
    }
    componentDidMount() {
        this.SuppliersGet();
    }
    UpdateSupplier = id => {
        window.location = '/Suppliers/Edit/' + id;
    }

    DetailSupplier = id => {
        window.location = '/Suppliers/Details/' + id;
    }

    DeleteSupplier = id => {
        window.location = '/Suppliers/Delete/' + id;
    }

    render() {
        const suppliers = this.state.suppliers;
        let contents = suppliers.length == 0 ? <img src="/Images/loading.gif" /> : this.supplierTable(suppliers);
        return (
            <div>
                {contents}
            </div>
        );
    }

    supplierTable(suppliers) {
        return <table className="table table-striped">
            <thead>
                <tr>
                    <td>Company Name</td>
                    <td>City</td>
                    <td>Country</td>
                    <td align="center">Actions</td>
                </tr>
            </thead>
            <tbody>
                {suppliers.map((supplier) => (
                    <tr key={supplier.id}>
                        <td>{supplier.companyName}</td>
                        <td>{supplier.city}</td>
                        <td>{supplier.country}</td>
                        <td align="left">
                            <button onClick={() => this.UpdateSupplier(supplier.id)} className="btn btn-primary"><i className="bi bi-pencil-square"></i>&nbsp;Edit</button>&nbsp;
                            <button onClick={() => this.DetailSupplier(supplier.id)} className="btn btn-primary"><i className="bi bi-card-list"></i>&nbsp;Detail</button>&nbsp;
                            <button onClick={() => this.DeleteSupplier(supplier.id)} className="btn btn-primary"><i className="bi bi-trash3"></i>&nbsp;Del</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    }
}

ReactDOM.render(<SupplierList />, document.getElementById('content'));