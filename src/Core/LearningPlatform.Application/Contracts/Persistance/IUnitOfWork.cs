using LearningPlatform.Application;

namespace LearningPlatform.Application.Contracts.Persistance;
public interface IUnitOfWork
{
    IBlogCommentRepository BlogCommentRepository { get; set; }
    IBlogRepository BlogRepository { get; set; }
    ICartItemRepository CartItemRepository { get; set; }
    ICartRepository CartRepository { get; set; }
    ICommentRepository CommentRepository { get; set; }
    ICourseRepository CourseRepository { get; set; }
    IPodcastRepository PodcastRepository { get; set; }
    ITeacherRepository TeacherRepository { get; set; }
    ITicketRepository TicketRepository { get; set; }
    ITopicRepository TopicRepository { get; set; }
    IVideoRepository VideoRepository { get; set; }
    IWalletRepository WalletRepository { get; set; }

    Task Save();
}