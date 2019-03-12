
function vCustomers() {

	this.tblCustomersId = 'tblCustomers';
	this.service = 'customer';
	this.ctrlActions = new ControlActions();
	this.columns = "Id,Name,LastName,Age";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCustomersId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCustomersId, true);
	}

	this.Create = function () {
		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, customerData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, customerData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, customerData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcustomer = new vCustomers();
	vcustomer.RetrieveAll();

});

