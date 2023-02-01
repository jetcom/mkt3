using Mkt3.Shared;

namespace Mkt3.Data;

public class CurrentNav
{
    public void SetTopics()
    {
        NotifyStateChanged();

    }

    public event Action onChange;
    private void NotifyStateChanged() => onChange?.Invoke();
}