function departmentInformationComponent() {
    const departmentId = document.getElementById("departmentId");
    const departmentStartDate = document.getElementById("departmentStartDate");
    const departmentCode = document.getElementById("departmentCode");
    const departmentName = document.getElementById("departmentName");
    const deparmentAddress = document.getElementById("deparmentAddress");
    const deparmentDescription = document.getElementById("deparmentDescription");
    const hospitalId = document.getElementById("hospitalId");

    const departmentObject =
    {
        department_id: 0,
        department_start_date: "2025-03-27T06:15:15.047Z",
        department_code: "string",
        department_name: "string",
        deparment_address: "string",
        deparment_description: "string",
        hospital_id: 0,
        created_by: 0,
        created_date: "2025-03-27T06:15:15.047Z",
        updated_date: "2025-03-27T06:15:15.047Z",
        updated_by: 0,
        flag: "string"
    }

    if (Validation(departmentObject) == true) {
        PostData(departmentObject)
        alert("Data Saved Successfully");

    }

    async function PostData(departmentObject) {
        const url = 'http://localhost:5247/api/DepartmentInformation'
        let res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(departmentObject)
        })

    }

    function Validation(departmentObject) {
        let isValide = true;

        // if (departmentObject.department_start_date.trim() == "") {
        //     isValide = false;
        //     alert("Please Enter Department Start Date");

        // }
        // else if (departmentObject.department_code.trim() == "") {
        //     isValide = false;
        //     alert("Please Enter Department Code");

        // }
        // else if (departmentObject.department_code.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.department_code.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.department_name.trim() == "") {
        //     isValide = false;
        //     alert("Please Enter Department Name");

        // }
        // else if (departmentObject.department_name.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.department_name.trim().length > 30) {
        //     alert("Please Enter Max 30 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.deparment_address.trim() == "") {
        //     isValide = false;
        //     alert("Please Enter Department Address");

        // }
        // else if (departmentObject.deparment_address.trim().length < 10) {
        //     alert("Please Enter Min 10 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.deparment_address.trim().length > 600) {
        //     alert("Please Enter Max 600 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.deparment_description.trim() == "") {
        //     isValide = false;
        //     alert("Please Enter Department Description");

        // }
        // else if (departmentObject.deparment_description.trim().length < 5) {
        //     alert("Please Enter Min 5 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.deparment_description.trim().length > 700) {
        //     alert("Please Enter Max 700 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.hospital_id.trim() == "") {
        //     isValide = false;
        //     alert("Please Enter Hospital ID");

        // }
        // else if (departmentObject.hospital_id.trim().length < 3) {
        //     alert("Please Enter Min 3 Characters");
        //     isValide = false;
        // }
        // else if (departmentObject.hospital_id.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters");
        //     isValide = false;
        // }
        return isValide;
    }
}