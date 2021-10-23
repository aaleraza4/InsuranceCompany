function getAllMessages() {

    $.ajax({
        url: '/SuperAdmin/GetAllMessages',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            console.log(result);

        }
    });
}
function getAllMessagesforMedicalInsurance() {

    $.ajax({
        url: '/SuperAdmin/GetAllMessagesforMedicalInsurance',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            console.log(result);

        }
    });
}
function getAllMessagesforLifeInsurance() {

    $.ajax({
        url: '/SuperAdmin/GetAllMessagesforLifeInsurance',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            console.log(result);

        }
    });
}