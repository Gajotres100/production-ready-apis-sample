using BoardGamesApi.Controllers;
using BoardGamesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BoardGamesApi.Tests.UnitTests
{
    public class GamesControllerTests
    {
        [Fact]
        public void Delete_IdIsNull_ReturnsNotFoundResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.Delete(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_IdIsEmpty_ReturnsNotFoundResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.Delete(string.Empty);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_IdDoesNotExists_ReturnsNotFoundResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.Delete("some-id");

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_IdExists_ReturnsOkResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.Delete("existing");

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetById_IdIsNull_ReturnsNotFoundResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.GetById(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_IdIsEmpty_ReturnsNotFoundResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.GetById(string.Empty);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_IdDoesNotExists_ReturnsNotFoundResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.GetById("some-id");

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_IdExists_ReturnsOkResult()
        {
            var controller = new GamesController(new FakeGamesRepository(), new FakeLogger());

            var result = controller.GetById("existing");

            Assert.IsType<OkObjectResult>(result);

            var resultValue = ((OkObjectResult) result).Value;
            Assert.IsType<ApiResult>(resultValue);

            var resultGame = ((ApiResult)resultValue).Data;
            Assert.IsType<Game>(resultGame);

            Assert.Equal("existing", ((Game) resultGame).Id);
        }
    }
}