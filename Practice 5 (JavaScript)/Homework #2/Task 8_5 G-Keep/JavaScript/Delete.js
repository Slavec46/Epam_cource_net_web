import {Array} from "./Array";

let note = document.querySelector('#notes_list');
note.addEventListener("click", deleteItem, event);

function deleteItem(event) {
    const target = event.target;
    
    if(target.tagName == 'BUTTON') {
        
        let qua = confirm('Удалить эту заметку?');
        if(qua) {
            let parent = target.parentElement.parentElement;
            parent.remove();

            let id = target.id.split('-')[3];
            ArrayNote.deleteById(id);
        }
    }
}