function itemInformationComponents() {
    const ItemId = document.getElementById("itemId")
    const ItemCode = document.getElementById("itemCode")
    const ItemType = document.getElementById("itemType")
    const ItemName = document.getElementById("itemName")
    const ItemManufactionName = document.getElementById("itemManufactionName")
    const ItemPacinking = document.getElementById("itemPacinking")
    const ItemUseName = document.getElementById("itemUseName")
    const ItemDescription = document.getElementById("itemDescription")
    const ItemStartDate = document.getElementById("itemStartDate")
    const ItemEndDate = document.getElementById("itemEndDate")
    const ItemFirstUnit = document.getElementById("itemFirstUnit")
    const ItemSecondUnit = document.getElementById("itemSecondUnit")
    const ItemConversionFirstFactor = document.getElementById("itemConversionFirstFactor")
    const ItemConversionSecondFactor = document.getElementById("itemConversionSecondFactor")
    const ItemIsStockebal = document.getElementById("itemIsStockebal")
    const ItemQualityCheck = document.getElementById("ItemQualityCheck")
    const ItemReturnPolicymId = document.getElementById("itemReturnPolicy")
    const ItemMinQty = document.getElementById("itemMinQty")
    const ItemMaxQty = document.getElementById("itemMaxQty")
    const ItemHsnCode = document.getElementById("itemHsnCode")
    const ItemPoType = document.getElementById("itemPoType")
    const ItemTaxApply = document.getElementById("itemTaxApply")
    const ItemPoTaxGroup = document.getElementById("itemPoTaxGroup")
    const ItemSaleTaxGroup = document.getElementById("itemSaleTaxGroup")

    const itemObject = {
        item_id: 0,
        item_code: ItemCode.value,
        item_type: ItemType.value,
        item_name: ItemName.value,
        item_manufaction_name: ItemManufactionName.value,
        item_pacinking: ItemPacinking.value,
        item_use_name: ItemUseName.value,
        item_description: ItemDescription.value,
        item_start_date: ItemStartDate.value,
        item_end_date: ItemEndDate.value,
        item_first_unit: ItemFirstUnit.value,
        item_second_unit: ItemSecondUnit.value,
        item_conversion_first_factor: ItemConversionFirstFactor.value,
        item_conversion_second_factor: ItemConversionSecondFactor.value,
        item_is_stockebal: ItemIsStockebal.value,
        item_quality_check: ItemQualityCheck.value,
        item_return_policy: ItemReturnPolicymId.value,
        item_min_qty: ItemMinQty.value,
        item_max_qty: ItemMaxQty.value,
        item_hsn_code: ItemHsnCode.value,
        item_po_type: ItemPoType.value,
        item_tax_apply: ItemTaxApply.value,
        item_po_tax_group: ItemPoTaxGroup.value,
        item_sale_tax_group: ItemSaleTaxGroup.value,
        created_by: 0,
        created_date: "2025-03-29T12:53:01.303Z",
        updated_by: 0,
        updated_date: "2025-03-29T12:53:01.303Z",
        activ_flag: 0,
        attr1: "string",
        attr2: "string",
        attr3: "string",
        attr4: 0,
        attr5: 0,
        attr6: 0,
        flag: "string"
    }

    if (Validation(itemObject) == true) {
        alert("Data Saved Successfully!")
        PostData(itemObject)
    }

    async function PostData(itemObject) {
        let url = 'http://localhost:5247/api/ItemInformation'
        let res = await fetch(url, {
            method: "Post",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(itemObject)
        })
    }


    function Validation(itemObject) {
        let isValide = true
        // if (itemObject.item_code.trim() == "") {
        //     alert("Plaese enter Item Code!")
        //     isValide = false
        // }
        return isValide
    }
}