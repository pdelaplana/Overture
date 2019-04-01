
function notify(message, duration){
  Snackbar.show({
		text: message,
		pos: 'bottom-center',
		showAction: false,
		actionText: "Dismiss",
		duration: duration,
		textColor: '#fff',
		backgroundColor: '#383838'
	});
}

function notifyOnChange(message, callback){
  Snackbar.show({
		text: message,
		pos: 'bottom-center',
    showAction: true,
    actionText: 'Save',
    actionTextColor: '#91C8F2',
    showSecondButton: true,
		duration: null,
		textColor: '#fff',
    backgroundColor: '#383838',
    onActionClick: callback
	});
}

function closeNotification(){
  Snackbar.close();
}

$(function(){

 
})
