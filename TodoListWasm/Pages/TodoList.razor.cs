using Microsoft.AspNetCore.Components;
using TodoList.Lib.DTO;
using TodoListWasm.Services;

namespace TodoListWasm.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskClientService _taskClientService { get; set; }

        private List<MyTaskDTO> myTaskDTOs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            myTaskDTOs = await _taskClientService.GetTaskList();
        }

    }
}
