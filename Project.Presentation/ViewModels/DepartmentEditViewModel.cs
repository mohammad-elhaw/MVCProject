namespace Project.Presentation.ViewModels
{
    public record DepartmentEditViewModel
    {
        public string Name { get; init; }
        public string Code { get; init; }
        public string? Description { get; init; }
        public DateOnly? DateOfCreation { get; init; }
    }
}
