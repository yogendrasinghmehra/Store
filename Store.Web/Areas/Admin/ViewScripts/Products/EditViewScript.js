$(function () {
    //removing product images
    $(document).on('click', '.lblImage', function () {
        var check = confirm('are you sure?');
        if (check) {
            var imz = $(this);
            if ($(this).data('id')) {
                $.ajax({
                    url: "/Admin/Products/RemoveImage",
                    data: { id: imz.data('id') },
                    type: "POST",
                    dataType: "json",
                    success: function (data) {
                        if (data.status) {
                            imz.parent().remove();
                        }
                        else { alert('problem in removing images'); }

                    }

                });

            }
        }

    })
    //removing product color
    $(document).on('click', '.productColor', function () {

        if ($(this).data('id') && $('#productId').val()) {
            var check = confirm('are you sure ?');
            var proId = $('#productId').val();
            var tag = $(this);            
            if (check)
            {
                debugger;
                $.ajax({
                    url: "/Admin/Products/RemoveColor",
                    type: "POST",
                    data: { colorId: tag.data('id'), productId: proId },
                    dataType: "json",
                    success: function (data) {
                        debugger;
                        tag.parent().remove();
                    }


                })

            }
        }

    })
    //removing product size
    $(document).on('click', '.productSize', function () {

        if ($(this).data('id') && $('#productId').val()) {
            var check = confirm('are you sure ?');
            var proId = $('#productId').val();
            var tag = $(this);
            if (check) {
                $.ajax({
                    url: "/Admin/Products/RemoveSize",
                    type: "POST",
                    data: { sizeId: tag.data('id'), productId: proId },
                    dataType: "json",
                    success: function (data) {                        
                        tag.parent().remove();
                    }


                })

            }
        }

    })


    //category changes
    $('#Product_CategoryId').change(function () {
        if ($(this).val())
        {
            $.ajax({
                url: "/Admin/Products/GetSubCategory",
                data: { CatId: $(this).val() },
                type: "POST",
                dataType: "json",
                success: function (data) {                   
                    $('#Product_SubCategoryId').empty();
                    $('#Product_ChildCategoryId').empty();
                    $.each(data, function (key, value) {
                        $('#Product_SubCategoryId').append("<option value='" + value.SubCategoryId + "'>" + value.SubCategoryName + "</option>");
                    })
                }

            });

        }
    })

    //Sub category changes
    $('#Product_SubCategoryId').change(function () {
        if ($(this).val()) {
            $.ajax({
                url: "/Admin/Products/GetChildCategory",
                data: { SubCatId: $(this).val() },
                type: "POST",
                dataType: "json",
                success: function (data) {
                    console.log(data);                   
                    $('#Product_ChildCategoryId').empty();
                    $.each(data, function (key, value) {
                        $('#Product_ChildCategoryId').append("<option value='" + value.ChildCategoryId + "'>" + value.ChildCategoryName + "</option>");
                    })
                }

            });

        }
    })
})