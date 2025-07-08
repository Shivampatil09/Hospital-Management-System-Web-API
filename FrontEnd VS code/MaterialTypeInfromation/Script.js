function materialTypeComponents() {
    const MaterialId = document.getElementById("materialId")
    const MaterialType = document.getElementById("materialType")
    const GlobalID = document.getElementById("globalID")

    const materialObject = {
        material_type_id: 0,
        material_type: MaterialType.value,
        global_id: GlobalID.value,
        created_by: 0,
        created_date: "2025-03-30T14:18:22.477Z",
        updated_by: 0,
        updated_date: "2025-03-30T14:18:22.477Z",
        flag: "string"
    }

    if (Validation(materialObject) == true) {
        alert("Data Saved Successfully!")
        PostData(materialObject)
    }

    async function PostData(materialObject) {
        let url = 'http://localhost:5247/api/MaterialTypeInfromation'
        let res = await fetch(url, {
            method: "Post",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(materialObject)
        })
    }

    function Validation(materialObject) {
        let isValide = true
        // if (materialObject.material_type.trim() == "") {
        //     alert("Please Enter Material type!")
        //     isValide = false
        // }
        // else if (materialObject.global_id.trim() == "") {
        //     alert("Please Enter Global ID !")
        //     isValide = false
        // }
        return isValide
    }
}