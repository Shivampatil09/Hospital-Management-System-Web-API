function clientRegistrationComponents() {
    const clientId = document.getElementById("clientId");
    const ClientCode = document.getElementById("ClientCode");
    const ClientName = document.getElementById("ClientName");
    const BusniessName = document.getElementById("busniessName");
    const ClientCity = document.getElementById("clientCity");
    const ClientPhone = document.getElementById("clientPhone");
    const ClientEmail = document.getElementById("clientEmail");
    const ClientGst = document.getElementById("clientGst");
    const ClientRegistrationNumber = document.getElementById("clientRegistrationNumber");
    const ClientPan = document.getElementById("clientPan");
    const UserName = document.getElementById("userName");
    const Password = document.getElementById("password");
    const ClientAddress = document.getElementById("clientAddress");


    const ClientObject = {

        client_id: 0,
        client_code: ClientCode.value,
        client_global_id: 0,
        client_name: ClientName.value,
        client_address: ClientAddress.value,
        client_phone: ClientPhone.value,
        client_city: ClientCity.value,
        busniess_name: BusniessName.value,
        client_pan: ClientPan.value,
        client_registration_no: ClientRegistrationNumber.value,
        client_gst: ClientGst.value,
        client_logo: "string",
        client_email: ClientEmail.value,
        password: Password.value,
        user_name: UserName.value,
        created_by: 0,
        active_flag: "string",
        attr1: "string",
        attr2: "string",
        attr3: "string",
        created_date: "2025-03-27T04:41:10.454Z",
        updated_date: "2025-03-27T04:41:10.454Z",
        flag: "string"
    }
    if (Validation(ClientObject) == true) {
        PostData(ClientObject)
        alert("Data Saved Successfully")

    }

    async function PostData(ClientObject) {
        const url = 'http://localhost:5247/api/ClientRegistration'
        let res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(ClientObject)
        })

    }

    function Validation(ClientObject) {
        let isValide = true;

        // if (ClientObject.client_code.trim() == "") {
        //     isValide = false;
        //     alert("Please Enter Client Code");

        // }
        // else if (ClientObject.client_code.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_code.trim().length > 4) {
        //     alert("Please Enter Max 4 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_name.trim() == "") {
        //     alert("Please Enter Client Name");
        //     isValide = false;
        // }
        // else if (ClientObject.client_name.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_name.trim().length > 50) {
        //     alert("Please Enter Max 50 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.busniess_name.trim() == "") {
        //     alert("Please Enter Business Name");
        //     isValide = false;
        // }
        // else if (ClientObject.busniess_name.trim().length < 4) {
        //     alert("Please Enter Min 4 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.busniess_name.trim().length > 50) {
        //     alert("Please Enter Max 50 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_city.trim() == "") {
        //     alert("Please Enter Client City");
        //     isValide = false;
        // }
        // else if (ClientObject.client_city.trim().length < 4) {
        //     alert("Please Enter Min 4 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_city.trim().length > 30) {
        //     alert("Please Enter Max 30 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_phone.trim() == "") {
        //     alert("Please Enter Client Phone Number");
        //     isValide = false;
        // }
        // else if (ClientObject.client_phone.trim().length < 15) {
        //     alert("Please Enter Min 15 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_phone.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_email.trim() == "") {
        //     alert("Please Enter Client Email");
        //     isValide = false;
        // }
        // else if (ClientObject.client_email.trim().length < 10) {
        //     alert("Please Enter Min 10 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_email.trim().length > 100) {
        //     alert("Please Enter Max 100 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_gst.trim() == "") {
        //     alert("Please Enter Client GST");
        //     isValide = false;
        // }
        // else if (ClientObject.client_gst.trim().length < 5) {
        //     alert("Please Enter Min 5 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_gst.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_registration_no.trim() == "") {
        //     alert("Please Enter Client Registration Numaber");
        //     isValide = false;
        // }
        // else if (ClientObject.client_registration_no.trim().length < 15) {
        //     alert("Please Enter Min 15 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_registration_no.trim().length > 30) {
        //     alert("Please Enter Max 30 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_pan.trim() == "") {
        //     alert("Please Enter Client PAN");
        //     isValide = false;
        // }
        // else if (ClientObject.client_pan.trim().length < 15) {
        //     alert("Please Enter Min 15 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_pan.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.user_name.trim() == "") {
        //     alert("Please Enter User Name");
        //     isValide = false;
        // }
        // else if (ClientObject.user_name.trim().length < 4) {
        //     alert("Please Enter Min 4 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.user_name.trim().length > 70) {
        //     alert("Please Enter Max 70 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.password.trim() == "") {
        //     alert("Please Enter Password");
        //     isValide = false;
        // }
        // else if (ClientObject.password.trim().length < 4) {
        //     alert("Please Enter Min 4 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.password.trim().length > 16) {
        //     alert("Please Enter Max 16 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_address.trim() == "") {
        //     alert("Please Enter Client Address");
        //     isValide = false;
        // }
        // else if (ClientObject.client_address.trim().length < 5) {
        //     alert("Please Enter Min 5 Characters");
        //     isValide = false;
        // }
        // else if (ClientObject.client_address.trim().length > 500) {
        //     alert("Please Enter Max 500 Characters");
        //     isValide = false;
        // }
        return isValide;
    }
}

async function GetData() {
    const clientbl = document.getElementById("clientbl")
    let url = 'http://localhost:5247/api/ClientRegistration'
    let res = await fetch(url)
    let Data = await res.json()
    console.log(Data)
    Data.forEach(element => {
        const row = document.createElement("tr")
        row.innerHTML = `<td>${element.client_id}</td>
        <td>${element.client_code}</td>
        <td>${element.client_name}</td>
        <td>${element.busniess_name}</td>
        <td>${element.client_city}</td>
         <td>${element.client_phone}</td>
         <td>${element.client_email}</td>
         <td>${element.client_gst}</td>
         <td>${element.client_registration_no}</td>
         <td>${element.client_pan}</td>
         <td>${element.user_name}</td>
         <td>${element.password}</td>
         <td>${element.client_address}</td>
         `
        clientbl.appendChild(row)
    });
}