using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;

namespace LearningPlatform.Persistance;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context,
        IBlogCommentRepository blogCommentRepository,
        IBlogRepository blogRepository,
        ICartItemRepository cartItemRepository,
        ICartRepository cartRepository,
        ICommentRepository commentRepository,
        ICourseRepository courseRepository,
        IPodcastRepository podcastRepository,
        ITeacherRepository teacherRepository,
        ITicketRepository ticketRepository,
        ITopicRepository topicRepository,
        IVideoRepository videoRepository,
        IWalletRepository walletRepository)
    {
        _context = context;
        BlogCommentRepository = blogCommentRepository;
        BlogRepository = blogRepository;
        CartItemRepository = cartItemRepository;
        CartRepository = cartRepository;
        CommentRepository = commentRepository;
        CourseRepository = courseRepository;
        PodcastRepository = podcastRepository;
        TeacherRepository = teacherRepository;
        TicketRepository = ticketRepository;
        TopicRepository = topicRepository;
        VideoRepository = videoRepository;
        WalletRepository = walletRepository;
    }

    public IBlogCommentRepository BlogCommentRepository { get; set; }
    public IBlogRepository BlogRepository { get; set; }
    public ICartItemRepository CartItemRepository { get; set; }
    public ICartRepository CartRepository { get; set; }
    public ICommentRepository CommentRepository { get; set; }
    public ICourseRepository CourseRepository { get; set; }
    public IPodcastRepository PodcastRepository { get; set; }
    public ITeacherRepository TeacherRepository { get; set; }
    public ITicketRepository TicketRepository { get; set; }
    public ITopicRepository TopicRepository { get; set; }
    public IVideoRepository VideoRepository { get; set; }
    public IWalletRepository WalletRepository { get; set; }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
