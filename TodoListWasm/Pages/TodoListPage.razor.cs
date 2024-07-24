using Microsoft.AspNetCore.Components;
using TodoList.Lib.Enums;
using TodoList.Lib.DTO;
using TodoListWasm.Services;

namespace TodoListWasm.Pages
{
    public partial class TodoListPage
    {
        [Inject] private ITaskClientService _taskClientService { get; set; }
        [Inject] private IUserClientService _userClientService { get; set; }

        private List<MyTaskDTO> myTaskDTOs;
        private List<UserDTO> listUser;
        private TaskSearch taskSearch = new TaskSearch();


        protected override async Task OnInitializedAsync()
        {
            myTaskDTOs = await _taskClientService.GetTaskList();
            listUser = await _userClientService.GetAllUser();
        }

    }

    public class TaskSearch
    {
        public string Name { get; set; }
        public Guid AssigneeID { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
