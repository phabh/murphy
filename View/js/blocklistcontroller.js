(function(){
	var app = angular.module('murphyApp',[]);
	app.controller('blockListController', function($scope){
		var self = this;
		$scope.blocklist = [];
		$scope.selectedBlock = {};
		$scope.selectedMessage = {};
		
		
		$scope.GetBlock = function(blockId) {
			return $scope.blocklist.filter((block)=>{
				return block.guid == blockId;
			})[0];
		};
		
		
		
		
		$scope.CreateDefault = function() {
			var newBlock = $scope.NewBlock();
			newBlock.name = "Default";
			
			var newTextMessage = $scope.NewText();
			newTextMessage.text = "Olá, esta é a resposta default para o que o usuário digitar";
			
			newBlock.messages.push(newTextMessage);
			
			return newBlock;
		};
		
		$scope.CreateMessage = function(){
			$scope.GetBlock($scope.selectedBlock).messages.push($scope.NewText());
		};
		
		$scope.CreateBlock = function(){
			$scope.blocklist.push($scope.NewBlock());
		};
		
		$scope.NewGuid = function guid() {
			function s4() {
				return Math.floor((1 + Math.random()) * 0x10000)
					.toString(16)
					.substring(1);
			}
			
			return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
		};
		
		
		$scope.NewBlock = function() {
			return {
				guid: $scope.NewGuid(),
				name: "Unnamed Block",
				messages: []
			};
		};
		
		$scope.NewText = function(){
			return {
				text: 'newText',
				buttons:[]
			};
		};
		
		$scope.NewImage = function() {
			return {
				url:"",
				buttons: []
			};
		};
		
		$scope.NewButton = function() {
			return {
				text: "",
				value:"",
				type:""
			};
		};
		
		$scope.NewGaleryElement = function() {
			return {
				header: {
					url:"",
					title:"",
					description:""
				},
				buttons: []
			}
		}
		
				$scope.blocklist.push($scope.CreateDefault());
		
	});
})();