$(document).ready(() => {
    $("#myInput").on("keyup", function () {
        var value = $(this).val();

        $("table tr").each(function (index) {
            if (index != 0) {

                $row = $(this);

                var name = $row.find("td:nth-child(3)").text().toLowerCase().replace(/(\r\n|\n|\r|\t)/gm, "");
                var id = $row.find("td:nth-child(2)").text().toLowerCase().replace(/(\r\n|\n|\r|\t)/gm, "");

                if ((name.indexOf(value.toLowerCase()) >= 0) ||
                    (id.indexOf(value.toLowerCase()) >= 0)) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            }
        });
    });
});


liveToastMessage = (message, origin) => {
    $('#toast-body').html(message);
    $('#toast-origin').html(origin);
    $('#toast-time').html(new Date().toLocaleTimeString('pt-BR', {
        hour12: false,
        hour: "numeric",
        minute: "numeric"
    }));
    const toastLiveMessages = $('#liveToast');
    const toast = new bootstrap.Toast(toastLiveMessages)

    toast.show()
}

msgModalMessage = (message, callback) => {
    $('#modal-body').html(message);
    $('#btnModalCallback').click(() => callback());

    $('#msgModal').modal('show');
}

closeMsgModalMessage = () => {
    $('#msgModal').modal('hide');
}

$(document).ready(function () {
    $("tr:odd").css({
        "background-color": "#d3d3d3",
        "color": "#000"
    });
});

let slideSearch = document.querySelector(".searchBar");

function showBar() {
    slideSearch.style.display = "block";
}