function hospitalInformationComponents() {
    const HospitalId = document.getElementById("hospitalId")
    const HospitalName = document.getElementById("hospitalName")
    const HospitalAddress = document.getElementById("hospitalAddress")
    const HospitalEmailAddress = document.getElementById("hospitalEmailAddress")
    const HospitalCity = document.getElementById("hospitalCity")
    const HospitalPan = document.getElementById("hospitalPan")
    const HospitalGstNumber = document.getElementById("hospitalGstNumber")
    const HospitalContactNumber = document.getElementById("hospitalContactNumber")
    const HospitalContactNumber1 = document.getElementById("hospitalContactNumber1")
    const HospitalWebSite = document.getElementById("hospitalWebSite")

    const hospitalObject = {
        hospital_id: 0,
        hospital_name: HospitalName.value,
        hospital_address: HospitalAddress.value,
        hospital_email_address: HospitalEmailAddress.value,
        logo: "string",
        hospital_city: HospitalCity.value,
        hospital_pan: HospitalPan.value,
        hospital_gst_number: HospitalGstNumber.value,
        hospital_contact_number: HospitalContactNumber.value,
        hospital_contact_number1: HospitalContactNumber1.value,
        hospital_web_site: HospitalWebSite.value,
        created_by: 0,
        created_date: "2025-03-29T12:37:57.649Z",
        updated_by: 0,
        updated_date: "2025-03-29T12:37:57.649Z",
        flag: "string"
    }

    if (Validation(hospitalObject) == true) {
        alert("Data Saved Successfully!")
        PostData(hospitalObject)
    }

    async function PostData(hospitalObject) {
        let url = 'http://localhost:5247/api/HospitalInformation'
        let res = await fetch(url, {
            method: "Post",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(hospitalObject)
        })
    }

    function Validation(hospitalObject) {
        let isValide = true
        if (hospitalObject.hospital_name.trim() == "") {
            alert("Plaese Enter Hospital Name!")
            isValide = false
        }
        else if (hospitalObject.hospital_name.trim().length < 2) {
            alert("Please Enter Min 2 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_name.trim().length > 50) {
            alert("Please Enter Min 50 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_address.trim() == "") {
            alert("Plaese Enter Hospital Address!")
            isValide = false
        }
        else if (hospitalObject.hospital_address.trim().length < 4) {
            alert("Please Enter Min 4 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_address.trim().length > 500) {
            alert("Please Enter Min 500 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_email_address.trim() == "") {
            alert("Plaese Enter Hospital Email!")
            isValide = false
        }
        else if (hospitalObject.hospital_city.trim() == "") {
            alert("Plaese Enter Hospital City!")
            isValide = false
        }
        else if (hospitalObject.hospital_city.trim().length < 4) {
            alert("Please Enter Min 4 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_city.trim().length > 500) {
            alert("Please Enter Min 500 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_pan.trim() == "") {
            alert("Plaese Enter Hospital PAN!")
            isValide = false
        }
        else if (hospitalObject.hospital_pan.trim().length < 10) {
            alert("Please Enter Min 10 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_pan.trim().length > 10) {
            alert("Please Enter Min 10 Characters")
            isValide = false
        }
        else if (hospitalObject.hospital_gst_number.trim() == "") {
            alert("Plaese Enter Hospital GST Number!")
            isValide = false
        }
        else if (hospitalObject.hospital_contact_number.trim() == "") {
            alert("Plaese Enter Hospital Contact Number!")
            isValide = false
        }
        else if (hospitalObject.hospital_web_site.trim() == "") {
            alert("Please Enter Hospita Website")
            isValide = false
        }
        return isValide
    }
}