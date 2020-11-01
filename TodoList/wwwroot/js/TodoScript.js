class TodoModel {
    constructor(Id, StartTime, EndTime, Title, Description, Priority) {
        this.Id = Id;
        this.StartTime = StartTime;
        this.EndTime = EndTime;
        this.Title = Title;
        this.Description = Description
        this.Priority = Priority;
    }
}

// Converting Ajax Context To Todo Object Model
var onSuccess = function (context) {
    const todoObject = new TodoModel();

    todoObject.Id = context.Id;
    todoObject.Title = context.Title;
    todoObject.Description = context.Description;
    todoObject.StartTime = context.StartTime;
    todoObject.EndTime = context.EndTime;
    todoObject.Priority = context.Priority;

    addRow(todoObject);
};
// Adding New Row To Todo Table 
const addRow = (todoObj) => {
    document.getElementById('todoTableBody').innerHTML += `<tr id=row${todoObj.id}>
        <td> ${fixDate(new Date(todoObj.StartTime), true)} </td>
        <td> ${fixDate(new Date(todoObj.EndTime), true)} </td>
        <td> ${todoObj.Title} </td>
        <td> ${todoObj.Description} </td>
        <td> ${todoObj.Priority} </td>
                <td>
                      <a href="/Todo/Edit/${todoObj.Id}" class="text-warning" onclick="return editTodoObj(${todoObj.Id})">Edit</a> |
                      <a href="/Todo/Details/${todoObj.Id}" class="text-info">Details</a> |
                      <a href="/Todo/Delete/${todoObj.Id}" class="text-danger" onclick="return deleteTodoObj(${todoObj.Id});">Delete</a>
                </td>   </tr>`;
};

// Delete Todo Object via XHR Request
const deleteTodoObj = (Id) => {
    let xhr = new XMLHttpRequest();
    xhr.open('POST', `/Todo/Delete/${Id}`, true);
    xhr.setRequestHeader('Content-type', 'text/html; charset=UTF-8');
    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            const rowToDelete = document.getElementById(`row${Id}`);
            rowToDelete.parentNode.removeChild(rowToDelete);
        }
    }
    xhr.send();
    return false;
};


const editTodoObj = (Id) => {
    const rowToEdit = document.getElementById(`row${Id}`);

    document.getElementById('start-input').value = fixDate(new Date(rowToEdit.cells[0].innerHTML), false);
    document.getElementById('end-input').value = fixDate(new Date(rowToEdit.cells[1].innerHTML), false);

    document.getElementById('title-input').value = rowToEdit.cells[2].innerHTML.replace(/\s/g, '');
    document.getElementById('description-input').value = rowToEdit.cells[3].innerHTML.replace(/\s/g, '');
    document.getElementById('priority-input').value = rowToEdit.cells[4].innerHTML.replace(/\s/g, '');
    document.getElementById('hiddenID').value = Id;

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

    todoObject.StartTime = document.getElementById('start-input').value;
    todoObject.EndTime = document.getElementById('end-input').value;
    todoObject.Title = document.getElementById('title-input').value;
    todoObject.Description = document.getElementById('description-input').value;
    todoObject.Priority = document.getElementById('priority-input').value;
    todoObject.Id = document.getElementById('hiddenID').value;

    return todoObject;
}

const sendEditRequest = () => {
    let todoData = JSON.stringify(getObjFromFields())
    //let xhr = new XMLHttpRequest();
    //xhr.open('POST', `/Todo/Edit`, true);
    //xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    //xhr.onreadystatechange = function () {
    //    if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
    //        alert(xhr.responseText);
    //    }
    //}
    //xhr.send(getObjFromFields());
    $.ajax({
        url: `/Todo/Edit`,
        type: "POST",
        data: todoData,
        contentType: "json",
        dataType: "json",
        error: function (response) {
            console.log(response.responseText);
        },
        success: function (response) {
            console.log(response);
        }
    });
}