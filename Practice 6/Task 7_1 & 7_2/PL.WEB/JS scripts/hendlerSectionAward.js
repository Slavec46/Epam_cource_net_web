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

    xhr.open("GET", '/Hendlers/AwardHandler.ashx?updateAward=');
    xhr.send(null);
}

function AddArticle(jsonObject) {

    let Id = jsonObject.Id;
    let Title = jsonObject.Title;
    let OwnerList = jsonObject.OwnerList;

    let h1 = document.createElement("h1");
    h1.setAttribute("name", "title");
    h1.textContent = Title;

    let paragOwner = document.createElement("p");
    paragOwner.textContent = "Владельцы:";

    let list = document.createElement("ol");
    list.setAttribute("name", "users");

    let item
    for (let i of OwnerList) {
        item = document.createElement("li");
        item.textContent = i.Name;
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
    article.appendChild(paragOwner);
    article.appendChild(list);
    article.appendChild(footer);

    article.addEventListener("click", RemoveArticle, true);
    section.appendChild(article);
}

function RemoveArticle(event) {
    let element = event.target;
    if (element.tagName == "BUTTON") {
        if (element.name == "btn-delete") {
            if (confirm("Действительно хотите удалить Награду?")) {
                xhr.open("GET", '/Hendlers/AwardHandler.ashx?removeAward=' + event.currentTarget.id);
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

    modalTitleValue = "Введите Заголовок";
    modalTitle.onfocus = onFocusText;
    modalTitle.onblur = onBlurText;
    modalTitle.value = modalTitleValue;
    modalTitle.style.color = "grey";

    let userObjects = JSON.parse(modalJson.textContent)
    for (let i of userObjects) {
        AddSelectOptionUsers(i.Id, i.Name);
    }

    btnModalClose.onclick = onCloseModel;
}

function AddSelectOptionUsers(id, title) {
    let option = document.createElement("OPTION");
    option.setAttribute("value", id);
    option.textContent = title;

    modalGroupUsers.append(option);
}

function onAddModel() {
    modalFormName.value = "Add";

    modalTitle.value = "Введите Заголовок";
    modalTitle.style.color = "grey";

    btnModalSubmit.textContent = "Добавить";
    modalWindow.parentNode.style.display = "block";
}

function onChangeModel() {
    if (event.target.tagName != "BUTTON") {
        modalFormName.value = "Change";
        modalId.value = event.currentTarget.id;

        modalTitle.value = event.currentTarget.children.namedItem("title").textContent;
        modalTitle.style.color = "black";

        btnModalSubmit.textContent = "Изменить";
        modalWindow.parentNode.style.display = "block";
    }
}