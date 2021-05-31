function deleteProductFromFavorite(id) {
    swal({
        title: "هشدار !!",
        text: "آیا از حذف اطمینان دارید ؟",
        icon: "warning",
        buttons: ["لغو", "بله"]
    }).then((isOk) => {
        if (isOk) {
            var products = localStorage.getItem(`products`);
            if (products && products != "undefined") {
                var productsJson = JSON.parse(products);
                var current = productsJson.filter(p => p.productId != id);
                var newValue = JSON.stringify(current);
                localStorage.setItem("products", newValue);
                Success();
                initTable();
            }
        }
    });
}
function AddProductToFavorite() {
    var id = window.location.pathname.split('/')[2];
    var products = localStorage.getItem(`products`);
    if (products && products != "undefined") {
        var productsJson = JSON.parse(products);
        var value = productsJson.find(p => p.productId == id);
        if (value) {
            productsJson = productsJson.filter(p => p.productId !== id);
            var newValue = JSON.stringify(productsJson);

            localStorage.setItem("products", newValue);
            return;
        } else {
            var title = $(".page-heading  h6").html();
            var brand = $(".brand").html();
            var image = $("#productImage").val();
            var currentProduct = {
                productTitle: title.trim(),
                productId: id,
                productImage: image,
                brand: brand,
                DiscountPercentage:null
            }
            productsJson.push(currentProduct);
            var newProducts = JSON.stringify(productsJson);
            localStorage.setItem("products", newProducts);
            Success("عملیات با موفقیت انجام شد.");
            $(".p-wishlist-share").remove();
        }
    } else {
        var pTitle = $(".page-heading  h6").html();
        var pBrand = $(".brand").html();
        var pImage = $("#productImage").val();
        var obj = [
            {
                productId: id,
                productTitle: pTitle.trim(),
                productImage: pImage,
                brand: pBrand,
                DiscountPercentage: null
            }
        ];
        var product = JSON.stringify(obj);
        localStorage.setItem(`products`, product);
        Success("عملیات با موفقیت انجام شد.");
        $(".p-wishlist-share").remove();
    }
}
$(document).ready(function () {
    var path = window.location.pathname;
    if (path.toLowerCase().includes("product")) {
        var id = path.split('/')[3];

        var products = localStorage.getItem(`products`);
        if (products && products != "undefined") {
            var productsJson = JSON.parse(products);
            var value = productsJson.find(p => p.productId === id);
            if (value) {
                $(".p-wishlist-share").remove();
            }
        }
    }
    if (path.toLowerCase().endsWith("/favorites")) {
        initTable();
    }
});

function initTable() {
    $("#wishlist").html(`<p id='not-found' class="text-center col-12 card p-2">موردی برای نمایش وجود ندارد</p>`);
    var products = localStorage.getItem("products");
    if (products && products != "undefined") {
        $("#not-found").remove();
        var productsConverted = JSON.parse(products);
        var tableBody = "";
        for (var item in productsConverted) {
            var currentProduct = productsConverted[item];
            tableBody += `
        <div class="col-6 col-md-4 col-lg-3">
                <div class="card top-product-card">
                    <div class="card-body">
                        <a class="wishlist-btn" href="#" onClick="deleteProductFromFavorite(${currentProduct.productId})">
                            <i class="lni lni-trash"></i>
                        </a>
                        <a class="product-thumbnail d-block" href="/Product/${currentProduct.productId}/${currentProduct.productTitle.replace(" ", "-")}">
                            <img class="mb-2" src="${currentProduct.productImage}" alt="">
                        </a>
                        <a class="product-title d-block" href="/Product/${currentProduct.productId}/${currentProduct.productTitle.replace(" ", "-")}">${currentProduct.productTitle}</a>
                    </div>
                </div>
            </div>`;
        }
        $("#wishlist").append(tableBody);
    }
}