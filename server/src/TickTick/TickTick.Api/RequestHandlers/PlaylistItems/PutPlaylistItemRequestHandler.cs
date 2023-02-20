using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.PlaylistItems
{
	public class PutPlaylistItemRequest : CommandBase<PlaylistItemDto>
    {
        public Guid PublicId { get; set; }
        public PlaylistItemDto Dto { get; }

        public PutPlaylistItemRequest(PlaylistItemDto dto,Guid id)
        {
            Dto = dto;
            PublicId = id;
        }
    }
    public class PutPlaylistItemRequestHandler : IRequestHandler<PutPlaylistItemRequest, PlaylistItemDto>
    {
        private readonly IRepository<PlaylistItem> playlistRepository;

        public PutPlaylistItemRequestHandler(IRepository<PlaylistItem> PlaylistRepository)
        {
            playlistRepository = PlaylistRepository;
        }

        public async Task<PlaylistItemDto> Handle(PutPlaylistItemRequest request, CancellationToken cancellationToken)
        {
            var item = await playlistRepository.GetAsync(p => p.PublicId == request.PublicId && p.IsDeleted == false);
            PlaylistItemDto dto = request.Dto;
            item.Update(dto.Title, dto.Text, dto.Description, dto.Performer);
            playlistRepository.Update(item);
            await playlistRepository.SaveAsync();
            return item.ConvertToDto();
        }
	}
}

