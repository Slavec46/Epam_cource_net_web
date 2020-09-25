window.onload = function () {

    xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                if (xhr.responseText != "") {
                    let jsonObject = JSON.parse(xhr.responseText);

                    AddArticle(jsonObject);
                    UpdateSection();
                }
            }
        }
    }

    InitializeElements();

    UpdateSection();
}

function onFocusText() {
    let Text = event.target;
    let Name;

    switch (Text.name) {
        case "text-name":
            Name = modalNameValue;
            break;
        case "dateOfBirth":
            Name = modalDateOfBirthValue;
            break;
        case "text-title":
            Name = modalTitleValue;
            break;
        case "login":
            Name = modalLoginValue;
            break;
        default:
            throw "Not found tagName!"
    }

    if (Text.value == Name && Text.style.color == "grey") {
        Text.value = "";
        Text.style.color = " black";
    }
}

function onBlurText() {
    let Text = event.target;
    let Name;

    switch (Text.name) {
        case "text-name":
            Name = modalNameValue;
            break;
        case "dateOfBirth":
            Name = modalDateOfBirthValue;
            break;
        case "text-title":
            Name = modalTitleValue;
            break;
        case "login":
            Name = modalLoginValue;
            break;
        default:
            throw "Not found tagName!"
    }

    if (Text.value == "") {
        Text.value = Name;
        Text.style.color = "grey";
    }
}

function onCloseModel() {
    modalWindow.parentNode.style.display = "none";
}