using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Repositories.Base;
using TickTick.Models;
using TickTick.Api.Dtos.Persons;

namespace TickTick.Api.RequestHandlers.PlaylistItems
{
	public class PostPlaylistRequest : CommandBase<PlaylistItemDto>
	{
        public PlaylistItemDto Dto { get; }

        public PostPlaylistRequest(PlaylistItemDto dto)
		{
            Dto = dto;
        }
    }
	public class PostPlaylistItemRequestHandler:IRequestHandler<PostPlaylistRequest,PlaylistItemDto>
	{
        private readonly IRepository<PlaylistItem> playlistRepository;

        public PostPlaylistItemRequestHandler(IRepository<PlaylistItem> PlaylistRepository)
		{
            playlistRepository = PlaylistRepository;
        }

        public async Task<PlaylistItemDto> Handle(PostPlaylistRequest request, CancellationToken cancellationToken)
        {
            PlaylistItem item = new PlaylistItem(request.Dto.Title,request.Dto.Performer,request.Dto.Type);
            item.CreatePublicId();
            playlistRepository.Add(item);
            await playlistRepository.SaveAsync();
            return new PlaylistItemDto();
        }
    }
}

