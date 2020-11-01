class TodoModel {
    constructor(id, startTime, endTime, title, description, priority) {
        this.id = id;
        this.startTime = startTime;
        this.endTime = endTime;
        this.title = title;
        this.description = description
        this.priority = priority;
    }
}

// Converting Ajax Context To Todo Object Model
var onSuccess = function (context) {
    const todoObject = new TodoModel();

    todoObject.id = context.id;
    todoObject.title = context.title;
    todoObject.description = context.description;
    todoObject.startTime = context.startTime;
    todoObject.endTime = context.endTime;
    todoObject.priority = context.priority;

    addRow(todoObject);
};
// Adding New Row To Todo Table 
const addRow = (todoObj) => {
    document.getElementById('todoTableBody').innerHTML += `<tr id=row${todoObj.id}>
        <td> ${fixDate(new Date(todoObj.startTime), true)} </td>
        <td> ${fixDate(new Date(todoObj.endTime), true)} </td>
        <td> ${todoObj.title} </td>
        <td> ${todoObj.description} </td>
        <td> ${todoObj.priority} </td>
                <td>
                      <a href="/Todo/Edit/${todoObj.id}" class="text-warning" onclick="return editTodoObj(${todoObj.id})">Edit</a> |
                      <a href="/Todo/Details/${todoObj.id}" class="text-info">Details</a> |
                      <a href="/Todo/Delete/${todoObj.id}" class="text-danger" onclick="return deleteTodoObj(${todoObj.id});">Delete</a>
                </td>   </tr>`;
};

// Delete Todo Object via XHR Request
const deleteTodoObj = (id) => {
    let xhr = new XMLHttpRequest();
    xhr.open('POST', `/Todo/Delete/${id}`, true);
    xhr.setRequestHeader('Content-type', 'text/html; charset=UTF-8');
    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            const rowToDelete = document.getElementById(`row${id}`);
            rowToDelete.parentNode.removeChild(rowToDelete);
        }
    }
    xhr.send();
    return false;
};


const editTodoObj = (id) => {
    const rowToEdit = document.getElementById(`row${id}`);

    document.getElementById('start-input').value = fixDate(new Date(rowToEdit.cells[0].innerHTML), false);
    document.getElementById('end-input').value = fixDate(new Date(rowToEdit.cells[1].innerHTML), false);

    document.getElementById('title-input').value = rowToEdit.cells[2].innerHTML.replace(/\s/g, '');
    document.getElementById('description-input').value = rowToEdit.cells[3].innerHTML.replace(/\s/g, '');
    document.getElementById('priority-input').value = rowToEdit.cells[4].innerHTML.replace(/\s/g, '');
    document.getElementById('hiddenID').value = id;

    document.getElementById('create-btn').classList.add('hide-me');
    document.getElementById('edit-btn').classList.remove('hide-me');

    return false;
}


const fixDate = (date, isForTable) => {
    let day = fixDateNum(date.getDate());      
    let month = fixDateNum(date.getMonth() + 1);
    let year = date.getFullYear();
    let hour = fixDateNum(date.getHours());
    let minute = fixDateNum(date.getMinutes());
    let second = fixDateNum(date.getSeconds());
    if (isForTable) {
        return day + "/" + month + "/" + year + " " + hour + ":" + minute + ":" + second;
    }
    else {
        return year + "-" + month + "-" + day + "T" + hour + ":" + minute + ":" + second;
    };
}

const fixDateNum = (number) => {
    return number > 9 ? number : "0" + number;
};

const getObjFromFields = () => {
    const todoObject = new TodoModel();

    todoObject.startTime = document.getElementById('start-input').value;
    todoObject.endTime = document.getElementById('end-input').value;
    todoObject.title = document.getElementById('title-input').value;
    todoObject.description = document.getElementById('description-input').value;
    todoObject.priority = document.getElementById('priority-input').value;
    todoObject.id = document.getElementById('hiddenID').value;

    return todoObject;
}

const sendEditRequest = () => {
    let xhr = new XMLHttpRequest();
    xhr.open('POST', `/Todo/Edit`, true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            const rowToDelete = document.getElementById(`row${id}`);
            rowToDelete.parentNode.removeChild(rowToDelete);
        }
    }
    xhr.send(JSON.stringify(getObjFromFields()));
}