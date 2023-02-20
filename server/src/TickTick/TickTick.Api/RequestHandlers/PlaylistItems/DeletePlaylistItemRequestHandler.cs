using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Api.RequestHandlers.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.PlaylistItems
{
	public class DeletePlaylistItemRequest : CommandBase<PlaylistItemDto>
	{

        public Guid PublicId { get; }

    public DeletePlaylistItemRequest(Guid publicId)
    {
        PublicId = publicId;
    }
}
public class DeletePlaylistItemRequestHandler : IRequestHandler<DeletePlaylistItemRequest, PlaylistItemDto>
{
    private readonly IRepository<PlaylistItem> playlistItemRepo;

    public DeletePlaylistItemRequestHandler(IRepository<PlaylistItem> repo)
    {
        this.playlistItemRepo = repo;
    }

    public async Task<PlaylistItemDto> Handle(DeletePlaylistItemRequest request, CancellationToken cancellationToken)
    {
        var p = await playlistItemRepo.GetAsync(p => p.PublicId == request.PublicId && p.IsDeleted == false);
        p.Delete();
        await playlistItemRepo.SaveAsync();
        return p.ConvertToDto();
    }
}
}

