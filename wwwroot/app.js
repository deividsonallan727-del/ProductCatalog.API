```javascript
var app = angular.module("productCatalog", []);

app.controller("ProductController", function ($scope, $http) {

    $scope.productType = "book";

    $scope.product = {};

    $scope.loading = false;

    $scope.successMessage = "";

    $scope.errorMessage = "";


    $scope.selectType = function (type) {

        $scope.productType = type;

        $scope.product = {};

        $scope.successMessage = "";

        $scope.errorMessage = "";
    };


    $scope.saveProduct = function () {

        $scope.loading = true;

        $scope.successMessage = "";

        $scope.errorMessage = "";


        var product = {

            name: $scope.product.name,

            description: $scope.product.description,

            price: $scope.product.price,

            quantity: $scope.product.quantity,

            type: $scope.productType === "book"
                ? "Book"
                : "Game"
        };


        if ($scope.productType === "book") {

            product.author = $scope.product.author;

            product.pages = $scope.product.pages;

        } else {

            product.platform = $scope.product.platform;

            product.genre = $scope.product.genre;
        }


        $http.post(
            "http://localhost:5211/api/products",
            product
        )
        .then(function (response) {

            $scope.successMessage =
                "Produto cadastrado com sucesso!";

            $scope.product = {};

        })
        .catch(function (error) {

            console.error(error);

            $scope.errorMessage =
                "Não foi possível cadastrar o produto.";

        })
        .finally(function () {

            $scope.loading = false;

        });
    };

});
```
