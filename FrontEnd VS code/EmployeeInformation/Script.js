function employeeInformationComponents() {
    const EmployeeId = document.getElementById("employeeId");
    const EmployeeCode = document.getElementById("employeeCode");
    const EmployeeTitle = document.getElementById("employeeTitle");
    const EmployeeGender = document.getElementById("employeeGender");
    const EmployeeName = document.getElementById("employeeName");
    const EmployyeDesignation = document.getElementById("employyeDesignation");
    const EmployeeDepartment = document.getElementById("employeeDepartment");
    const EmployeeDob = document.getElementById("employeeDob");
    const EmployeeJoingDate = document.getElementById("employeeJoingDate");
    const EmployeeAddress = document.getElementById("employeeAddress");
    const EmployeeAddress1 = document.getElementById("employeeAddress1");
    const EmployeeCity = document.getElementById("employeeCity");
    const EmployeePan = document.getElementById("employeePan");
    const EmployeeAdharchard = document.getElementById("employeeAdharchard");
    const EmployeeAlternetNo = document.getElementById("employeeAlternetNo");
    const EmployeeMobile = document.getElementById("employeeMobile");
    const EmployeeEmailId = document.getElementById("employeeEmailId");
    const EmployeeBankName = document.getElementById("employeeBankName");
    const EmployeeAccountNo = document.getElementById("employeeAccountNo");
    const EmployeeIfscCode = document.getElementById("employeeIfscCode");
    const EmployeeBranch = document.getElementById("employeeBranch");

    const employeeObject = {
        employee_id: 0,
        employee_code: EmployeeCode.value,
        employee_title: EmployeeTitle.value,
        employee_gender: EmployeeGender.value,
        employee_name: EmployeeName.value,
        employye_designation: EmployyeDesignation.value,
        employee_department: EmployeeDepartment.value,
        employee_dob: EmployeeDob.value,
        employee_joing_date: EmployeeJoingDate.value,
        employee_Address: EmployeeAddress.value,
        employee_Address1: EmployeeAddress1.value,
        employee_city: EmployeeCity.value,
        employee_pan: EmployeePan.value,
        employee_adharchard: EmployeeAdharchard.value,
        employee_alternet_no: EmployeeAlternetNo.value,
        employee_mobile: EmployeeMobile.value,
        employee_email_id: EmployeeEmailId.value,
        employee_bank_name: 0,
        employee_account_no: EmployeeAccountNo.value,
        employee_ifsc_code: EmployeeIfscCode.value,
        employee_branch: 0,
        employee_photo: "string",
        created_by: 0,
        updated_by: 0,
        created_date: "2025-03-28T05:07:34.295Z",
        updated_date: "2025-03-28T05:07:34.295Z",
        active_flag: 0,
        attr1: "string",
        attr2: "string",
        attr3: "string",
        attr4: 0,
        flag: "string"
    }

    if (Validation(employeeObject) == true) {
        alert("Data Saved Successfully");
        PostData(employeeObject)
    }

    async function PostData(employeeObject) {
        let url = 'http://localhost:5247/api/EmployeeInformation'
        let res = await fetch(url, {
            method: 'Post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(employeeObject)
        })
    }

    function Validation(employeeObject) {
        let isValide = true;
        // if (employeeObject.employee_code.trim() == "") {
        //     alert("Please Enter Employee Code!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_code.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_code.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_title.trim() == "") {
        //     alert("Please Enter Employee Title!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_title.trim().length < 3) {
        //     alert("Please Enter Min 2 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_title.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_gender.trim() == "") {
        //     alert("Please Enter Employee Gender!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_gender.trim().length < 4) {
        //     alert("Please Enter Min 4 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_gender.trim().length > 6) {
        //     alert("Please Enter Max 6 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_name.trim() == "") {
        //     alert("Please Enter Employee Name!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_name.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_name.trim().length > 50) {
        //     alert("Please Enter Max 50 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employye_designation.trim() == "") {
        //     alert("Please Enter Employee Designation!")
        //     isValide = false;
        // }
        // else if (employeeObject.employye_designation.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employye_designation.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_department.trim() == "") {
        //     alert("Please Enter Employee Department!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_department.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_department.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_dob.trim() == "") {
        //     alert("Please Enter Employee Date OF Birth!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_joing_date.trim() == "") {
        //     alert("Please Enter Employee Joing Date!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_Address.trim() == "") {
        //     alert("Please Enter Employee Address!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_Address.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_Address.trim().length > 500) {
        //     alert("Please Enter Max 500 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_city.trim() == "") {
        //     alert("Please Enter Employee City!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_city.trim().length < 4) {
        //     alert("Please Enter Min 4 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_city.trim().length > 100) {
        //     alert("Please Enter Max 100 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_pan.trim() == "") {
        //     alert("Please Enter Employee PAN!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_pan.trim().length < 10) {
        //     alert("Please Enter Min 10 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_pan.trim().length > 10) {
        //     alert("Please Enter Max 10 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_adharchard.trim() == "") {
        //     alert("Please Enter Employee Adharchard!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_adharchard.trim().length < 12) {
        //     alert("Please Enter Min 12 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_adharchard.trim().length > 12) {
        //     alert("Please Enter Max 12 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_mobile.trim() == "") {
        //     alert("Please Enter Mobile Number!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_mobile.trim().length < 15) {
        //     alert("Please Enter Min 15 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_mobile.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_email_id.trim() == "") {
        //     alert("Please Enter Employee Email!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_bank_name.trim() == "") {
        //     alert("Please Enter Bank Name!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_account_no.trim() == "") {
        //     alert("Please Enter Account Number!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_account_no.trim().length < 12) {
        //     alert("Please Enter Min 12 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_account_no.trim().length > 12) {
        //     alert("Please Enter Max 12 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_ifsc_code.trim() == "") {
        //     alert("Please Enter IFSC!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_ifsc_code.trim().length < 6) {
        //     alert("Please Enter Min 6 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_ifsc_code.trim().length > 6) {
        //     alert("Please Enter Max 6 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_branch.trim() == "") {
        //     alert("Please Enter Employee Branch!")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_branch.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters")
        //     isValide = false;
        // }
        // else if (employeeObject.employee_branch.trim().length > 100) {
        //     alert("Please Enter Max 100 Characters")
        //     isValide = false;
        // }
        return isValide
    }
}