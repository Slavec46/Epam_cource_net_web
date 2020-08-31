import {Service} from "./Array";
export var ArrayNote = new Service();

let modal = document.getElementById("ModalCreate");
let mainBtn = document.getElementById("b__main__create");
let mainBtn_create = document.getElementById("b__create");
let mainBtn_close = document.getElementById("b__close");

export let bodyNode = document;
// show modal window for create note
mainBtn.onclick = function() {
  modal.classList.toggle("btn__show");
}

// btn Create note
mainBtn_create.onclick = function() {
  let node = document.getElementById("base");
  let temp = node.cloneNode(true);

  let arrayHeadDivModal = bodyNode.getElementById("modal-content-head").childNodes;
  let arrayBodyDivModal = bodyNode.getElementById("modal-content-body").childNodes;

  let stringHeadText = "";
  let stringBodyText = "";

  let noteList = document.getElementById("notes__list");

  noteList.append(temp);
  temp.id = `note__item-${ArrayNote.id()}`

  for (let index = 0; index < arrayHeadDivModal.length; index++) {

    if (arrayHeadDivModal.length > 0) {
      stringHeadText += arrayHeadDivModal[index].textContent + '<br>';
    }
  }
  temp.querySelectorAll("span")[0].innerHTML = stringHeadText;

  for (let index = 0; index < arrayBodyDivModal.length; index++) {

    if (arrayBodyDivModal.length > 0) {
      stringBodyText += arrayBodyDivModal[index].textContent + '<br>';
    }
  }
  temp.querySelectorAll("span")[1].innerHTML = stringBodyText;

  temp.querySelectorAll("span")[0].id = `content__head-text-${ArrayNote.id()}`;
  temp.querySelectorAll("span")[1].id = `content__body-text-${ArrayNote.id()}`;
  temp.querySelectorAll("button")[0].id = `note-deleted-buttom-${ArrayNote.id()}`;

  ArrayNote.add(temp);

  bodyNode.getElementById("modal-content-head").innerHTML = '';
  bodyNode.getElementById("modal-content-body").innerHTML = '';

}

//btn close 
mainBtn_close.onclick = function() {
  modal.classList.toggle("btn__show");
  bodyNode.getElementById("modal-content-head").innerHTML = '';
  bodyNode.getElementById("modal-content-body").innerHTML = '';
}