using Microsoft.AspNetCore.Components;
using TodoList.Lib.DTO;
using TodoListWasm.Services;

namespace TodoListWasm.Pages
{
    public partial class TaskDetail
    {

        [Parameter]
        public string? TaskId { get; set; }
        [Inject] private ITaskClientService taskClientService { set; get; }

        private MyTaskDTO? taskDTO { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(TaskId)) 
            {
                taskDTO = await taskClientService.GetTask(TaskId);
            }
        }

    }
}
