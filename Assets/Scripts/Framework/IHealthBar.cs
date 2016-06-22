public interface IHealthBar {
    /// <summary>
    /// Sets the current health shown on the health bar.
    /// </summary>
    /// <param name="percent">A float, from 0 to 1, representing the amount of health on the bar.</param>
    void SetHealth (float percent);
}
