$(function () {

    $('#CategoryId').on('change', function () {
        if ($(this).val()) {
            var dataToSend = { CatId: $(this).val() };
            $.ajax({
                url: "/Admin/Products/GetSubCategory",
                data: dataToSend,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $('#SubCategoryId').empty();
                    $('#ChildCategoryId').empty();
                    $('#SubCategoryId').append("<option value=''>Select Sub Category</option>");

                    if (data) {
                        $.each(data, function (key, value) {
                            $('#SubCategoryId').append("<option value='" + value.SubCategoryId + "'>" + value.SubCategoryName + "</option>");

                        })
                    }


                }
            })
        }
    });

    $('#SubCategoryId').on('change', function () {
        if ($(this).val()) {
            var dataToSend = { SubCatId: $(this).val() };
            $.ajax({
                url: "/Admin/Products/GetChildCategory",
                data: dataToSend,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $('#ChildCategoryId').empty();
                    $('#ChildCategoryId').append("<option  value=''>Select Child Category</option>");
                    if (data) {
                        $.each(data, function (key, value) {
                            $('#ChildCategoryId').append("<option value='" + value.ChildCategoryId + "'>" + value.ChildCategoryName + "</option>");

                        });
                    }


                }
            })
        }
        else { $('#ChildCategoryId').empty(); }
    });

})