function BindData(results) {
    $('#ProductBody').empty();
    $.each(results, function (key, value) {
        $('#ProductBody').append("<tr><td>" + value.Name + "</td><td>" + value.Price + "</td><td>" + value.Stock + "</td><td><a href='/Admin/Products/Details/" + value.ProductId + "'>Details</a> | <a href='/Admin/Products/Edit/" + value.ProductId + "'>Edit</a> | <a href='/Admin/Products/Delete/" + value.ProductId + "'>Delete</a></td></tr>")

    });

}
function BindSubCategory(CategoryList) {
    $('#SubCategory').append("<option value=''>Select Sub Category</option>");
    $.each(CategoryList, function (key, value) {
        $('#SubCategory').append("<option  value='" + value.SubCategoryId + "'>" + value.SubCategoryName + "</option>");

    });
}
function BindChildCategory(CategoryList) {
    $('#ChildCategory').append("<option value=''>Select Child Category</option>");
    $.each(CategoryList, function (key, value) {
        $('#ChildCategory').append("<option  value='" + value.ChildCategoryId + "'>" + value.ChildCategoryName + "</option>");

    });
}


$(function () {
    $('#MainCategory').on("change", function () {
        if ($(this).val()) {

            $.ajax({
                url: "/Admin/Products/GetProductsListByCategory",
                data: { CategoryId: $(this).val() },
                type: "POST",
                dataType: "json",
                success: function (data) {
                    $('#SubCategory').empty();
                    $('#ChildCategory').empty();
                    if (data.productList) {
                        BindData(data.productList);
                    }
                    if (data.SubCategoryList) {
                        BindSubCategory(data.SubCategoryList);

                    }
                }
            })
        }
    })

    //sub category on change
    $('#SubCategory').on("change", function () {
        if ($(this).val()) {

            $.ajax({
                url: "/Admin/Products/GetProductsListBySubCategory",
                data: { SubCategoryId: $(this).val() },
                type: "POST",
                dataType: "json",
                success: function (data) {
                    $('#ChildCategory').empty();
                    if (data.productList) {
                        BindData(data.productList);
                    }
                    if (data.ChildCategoryList) {
                        BindChildCategory(data.ChildCategoryList);
                    }
                }
            })
        }
    })

    //sub category on change
    $('#ChildCategory').on("change", function () {
        if ($(this).val()) {

            $.ajax({
                url: "/Admin/Products/GetProductsListByChildCategory",
                data: { ChildCategoryId: $(this).val() },
                type: "POST",
                dataType: "json",
                success: function (data) {
                    if (data.productList) {
                        BindData(data.productList);
                    }
                }
            })
        }
    })


})