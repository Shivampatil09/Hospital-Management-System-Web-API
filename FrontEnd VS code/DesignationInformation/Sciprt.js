function designationInformationComponents() {
    const DesignationId = document.getElementById("designationId");
    const DesignationName = document.getElementById("designationName");
    const DesignationQualification = document.getElementById("designationQualification");
    const DesignationDescription = document.getElementById("designationDescription");
    const DesignationCode = document.getElementById("designationCode");

    const designationObject = {
        designation_id: 0,
        designation_code: DesignationCode.value,
        designation_name: DesignationName.value,
        designation_qualification: DesignationQualification.value,
        designation_description: DesignationDescription.value,
        created_date: "2025-03-27T06:15:15.047Z",
        updated_date: "2025-03-27T06:15:15.047Z",
        created_by: 0,
        updated_by: 0,
        ac_flag: 0,
        flag: "string"
    }
    if (Validation(designationObject) == true) {
        alert("Data Saved Successfuly");
        PostData(designationObject)
    }

    async function PostData(designationObject) {
        const url = 'http://localhost:5247/api/DesignationInformation'
        let res = await fetch(url, {
            method: 'Post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(designationObject)
        })
    }

    function Validation(designationObject) {
        let isValide = true;

        // if (designationObject.designation_name.trim() == "") {
        //     alert("Please Enter Designation Name!");
        //     isValide = false;
        // }
        // else if (designationObject.designation_name.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters");
        //     isValide = false;
        // }
        // else if (designationObject.designation_name.trim().length > 50) {
        //     alert("Please Enter Max 50 Characters");
        //     isValide = false;
        // }
        // else if (designationObject.designation_qualification.trim() == "") {
        //     alert("Please Enter Designation Qualification!");
        //     isValide = false;
        // }
        // else if (designationObject.designation_qualification.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters");
        //     isValide = false;
        // }
        // else if (designationObject.designation_qualification.trim().length > 60) {
        //     alert("Please Enter Max 60 Characters");
        //     isValide = false;
        // }
        // else if (designationObject.designation_description.trim() == "") {
        //     alert("Please Enter Designation Description!");
        //     isValide = false;
        // }
        // else if (designationObject.designation_description.trim().length < 5) {
        //     alert("Please Enter Min 5 Characters");
        //     isValide = false;
        // }
        // else if (designationObject.designation_description.trim().length > 700) {
        //     alert("Please Enter Max 700 Characters");
        //     isValide = false;
        // }
        // else if (designationObject.designation_code.trim() == "") {
        //     alert("Please Enter Designation Code!");
        //     isValide = false;
        // }
        // else if (designationObject.designation_code.trim().length < 2) {
        //     alert("Please Enter Min 2 Characters");
        //     isValide = false;
        // }
        // else if (designationObject.designation_code.trim().length > 15) {
        //     alert("Please Enter Max 15 Characters");
        //     isValide = false;
        // }
        return isValide;
    }
}