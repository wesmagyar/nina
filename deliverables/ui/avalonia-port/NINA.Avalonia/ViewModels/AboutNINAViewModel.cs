namespace NINA.Avalonia.ViewModels;

public class AboutNINAViewModel : ViewModelBase
{
    public string Version { get; } = "1.0.0"; // Placeholder for actual version
    
    public string HomepageUrl { get; } = "https://nighttime-imaging.eu/";
    
    public string DocumentationUrl { get; } = "https://nighttime-imaging.eu/documentation/";
    
    public string DiscordUrl { get; } = "http://discord.gg/fwpmHU4";
    
    public string RepositoryUrl { get; } = "https://github.com/wesmagyar/nina/";
    
    public string ChangelogUrl { get; } = "https://nighttime-imaging.eu/changelog/";
    
    public string CrowdinUrl { get; } = "https://nina.crowdin.com/nina";
    
    public string DonationUrl { get; } = "https://nighttime-imaging.eu/donate/";
    
    public string CopyrightHolder { get; } = "Stefan Berg";
    
    public string CopyrightEmail { get; } = "isbeorn86+NINA@googlemail.com";
    
    public string CopyrightYears { get; } = "2016 - 2026";
}