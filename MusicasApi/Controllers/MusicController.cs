using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicasApi.Data;
using MusicasApi.Data.DTOs;
using MusicasApi.Models;

namespace MusicasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : Controller
    {
        private MusicContext _musicContext;
        private IMapper _mapper;

        public MusicController(MusicContext musicContext, IMapper mapper)
        {
            _musicContext = musicContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona uma música no banco de dados
        /// </summary>
        /// <param name="musicaDto">Objeto com campos necessários para criação de uma música</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Adição feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreatedMusic([FromBody] CreatedMusicDto musicaDto)
        {
            Music musica = _mapper.Map<Music>(musicaDto);
            _musicContext.Add(musica);
            _musicContext.SaveChanges();
            return CreatedAtAction(nameof(GetMusicById), new { Id = musica.Id }, musica);
        }

        /// <summary>
        /// Busca uma música pelo id
        /// </summary>
        /// <param name="id">Id da música que deseja buscar do banco de dados</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Música retornada com sucesso</response>
        /// <response code="404">Músicanão encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMusicById(int id)
        {
            Music music = _musicContext.Musicas.FirstOrDefault(music => music.Id == id);

            if (music == null)
                return NotFound();
            ReadMusicDto musicDto = _mapper.Map<ReadMusicDto>(music);
            return Ok(musicDto);

        }

        /// <summary>
        /// Atualiza música utilizando o seu Id
        /// </summary>
        /// <param name="id">Id da música que deseja atualizar</param>
        /// <param name="musicDto">Objeto com os campos necessários para atualização de música</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Música retornada com sucesso</response>
        /// <response code="404">Músicanão encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateMusic(int id, [FromBody] UpdateMusicDto musicDto)
        {
            Music music = _musicContext.Musicas.FirstOrDefault(music => music.Id == id);
            if (music == null)
                return NotFound();

            _mapper.Map(musicDto, music);
            _musicContext.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deleta música utilizando seu Id
        /// </summary>
        /// <param name="id">Id da música que deseja deletar</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Música retornada com sucesso</response>
        /// <response code="404">Músicanão encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMusic(int id)
        {
            Music music = _musicContext.Musicas.FirstOrDefault(music => music.Id == id);
            if (music == null)
                return NotFound();

            _musicContext.Remove(music);
            _musicContext.SaveChanges();
            return NoContent();
        }
    }
}
