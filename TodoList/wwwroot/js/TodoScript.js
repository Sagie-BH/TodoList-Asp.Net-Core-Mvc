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
const todoObject = new TodoModel();

// Converting Ajax Context To Todo Object Model
var onSuccess = function (context) {
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
        <td> ${todoObj.startTime} </td>
        <td> ${todoObj.endTime} </td>
        <td> ${todoObj.title} </td>
        <td> ${todoObj.description} </td>
        <td> ${todoObj.priority} </td>
                <td>
                      <a href="/Todo/Edit/${todoObj.id}">Edit</a> |
                      <a href="/Todo/Details/${todoObj.id}">Details</a> |
                      <a href="/Todo/Delete/${todoObj.id}" onclick="return deleteTodoObj(${todoObj.id});">Delete</a>
                </td>   </tr>`;
};

const deleteTodoObj = (id) => {
    sendDeleteRequest(id);
    return false;
};

const sendDeleteRequest = (id) => {
    let xhr = new XMLHttpRequest();
    xhr.open('POST',`/Todo/Delete/${id}`, true);
    xhr.setRequestHeader('Content-type', 'text/html; charset=UTF-8');
    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            const rowToDelete = document.getElementById(`row${id}`);
            rowToDelete.parentNode.removeChild(rowToDelete);
        }
    }
    xhr.send();
}
