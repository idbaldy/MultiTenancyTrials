using Abp.Application.Services.Dto;

namespace MultiTenancyTrials.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

