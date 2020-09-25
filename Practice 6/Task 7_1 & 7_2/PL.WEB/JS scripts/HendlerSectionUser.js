let xhr;

function UpdateSection(clearSection) {
    if (clearSection) {
        let child = section.firstElementChild;
        let oldChild;
        while (child) {
            if (child.tagName == "ARTICLE") {
                oldChild = child;
                child = child.nextElementSibling;
                section.removeChild(oldChild);
            }
            else {
                child = child.nextElementSibling;
            }
        }
    }

    xhr.open("GET", '/Hendlers/UserHandler.ashx?updateUser=');
    xhr.send(null);
}

function AddArticle(jsonObject) {

    let Id = jsonObject.Id;
    let Name = jsonObject.Name;
    let DateOfBirth = jsonObject.DateOfBirth;
    let AwardList = jsonObject.AwardList;

    let h1 = document.createElement("h1");
    h1.setAttribute("name", "name");
    h1.textContent = Name;

    let paragDateOfBirth = document.createElement("p");
    paragDateOfBirth.textContent = DateOfBirth;
    paragDateOfBirth.setAttribute("name", "dateOfBirth");

    let paragAward = document.createElement("p");
    paragAward.textContent = "Награды:";

    let list = document.createElement("ol");
    list.setAttribute("name", "awards");

    let item
    for (let i of AwardList) {
        item = document.createElement("li");
        item.textContent = i.Title;
        list.appendChild(item);
    }

    let btnDelete = document.createElement("button");
    btnDelete.setAttribute("name", "btn-delete");
    btnDelete.textContent = "Удалить";

    let footer = document.createElement("footer");
    footer.appendChild(btnDelete);

    let article = document.createElement("article");
    article.setAttribute("id", Id);
    if (userRole.textContent != 'user') {
        article.onclick = onChangeModel;
    }
    article.appendChild(h1);
    article.appendChild(paragDateOfBirth);
    article.appendChild(paragAward);
    article.appendChild(list);
    article.appendChild(footer);

    article.addEventListener("click", RemoveArticle, true);
    section.appendChild(article);
}

function RemoveArticle(event) {
    let element = event.target;
    if (element.tagName == "BUTTON") {
        if (element.name == "btn-delete") {
            if (confirm("Действительно хотите удалить пользователя?")) {
                xhr.open("GET", '/Hendlers/UserHandler.ashx?removeUser=' + event.currentTarget.id);
                xhr.send(null);

                UpdateSection(true);
            }
        }
    }
}

function InitializeElements() {
    let btnAdd = document.getElementById("btn-add");
    btnAdd.onclick = onAddModel;
    let btnUpdate = document.getElementById("btn-update");
    btnUpdate.onclick = UpdateSection;

    modalLoginValue = "Введите логин";
    modalLogin.onfocus = onFocusText;
    modalLogin.onblur = onBlurText;
    modalLogin.value = modalLoginValue;
    modalLogin.style.color = "grey";

    modalNameValue = "Введите имя";
    modalName.onfocus = onFocusText;
    modalName.onblur = onBlurText;
    modalName.value = modalNameValue;
    modalName.style.color = "grey";

    modalDateOfBirthValue = "Введите дату рождения в формате (dd-mm-yyyy):";
    modalDateOfBirth.onfocus = onFocusText;
    modalDateOfBirth.onblur = onBlurText;
    modalDateOfBirth.value = modalDateOfBirthValue;
    modalDateOfBirth.style.color = "grey";

    let awardObjects = JSON.parse(modalJson.textContent)
    for (let i of awardObjects) {
        AddSelectOptionAwards(i.Id, i.Title);
    }

    btnModalClose.onclick = onCloseModel;
}

function AddSelectOptionAwards(id, name) {
    let option = document.createElement("OPTION");
    option.setAttribute("value", id);
    option.textContent = name;

    modalGroupAwards.append(option);
}

function onAddModel() {
    modalFormName.value = "Add";

    modalLogin.style.display = "block";
    modalPassword.style.display = "block";

    modalName.value = "Введите имя";
    modalName.style.color = "grey";

    modalDateOfBirth.value = "Введите дату рождения в формате (dd-mm-yyyy):";
    modalDateOfBirth.style.color = "grey";

    btnModalSubmit.textContent = "Добавить";
    modalWindow.parentNode.style.display = "block";
}

function onChangeModel() {
    if (event.target.tagName != "BUTTON") {
        modalFormName.value = "Change";
        modalId.value = event.currentTarget.id;

        modalLogin.style.display = "none";
        modalPassword.style.display = "none";

        modalName.value = event.currentTarget.children.namedItem("name").textContent;
        modalName.style.color = "black";

        modalDateOfBirth.value = event.currentTarget.children.namedItem("dateOfBirth").textContent;
        modalDateOfBirth.style.color = "black";

        btnModalSubmit.textContent = "Изменить";
        modalWindow.parentNode.style.display = "block";
    }
}