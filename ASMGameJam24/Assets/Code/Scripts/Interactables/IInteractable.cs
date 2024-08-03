public interface IInteractable
{
	string ObjectType { get; }
	bool HasBeenClicked { get; set; }

	void PlayAnimationAndCompleteTask(TaskManager taskManager);
}