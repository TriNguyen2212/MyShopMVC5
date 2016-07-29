(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {

        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.moreImages = $scope.product.moreImages;

        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                if (result.data.MoreImages != null)
                    $scope.moreImages = JSON.parse(result.data.MoreImages);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.UpdateProduct = UpdateProduct;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function UpdateProduct() {
            $scope.product.MoreImages =JSON.stringify($scope.moreImages);
            apiService.put('/api/product/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadCategories() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            },
            function () {
                console.log("canot get list parents");
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });
            }
            finder.popup();
        }
        $scope.moreImages = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    if ($.inArray(fileUrl, $scope.moreImages) < 0) {
                        $scope.moreImages.push(fileUrl);
                    }
                    else
                        notificationService.displayWarning('Hình này đã được chọn !');
                });
            }
            finder.popup();
        }
        loadCategories();
        loadProductDetail();
    };

})(angular.module('tedushop.products'));