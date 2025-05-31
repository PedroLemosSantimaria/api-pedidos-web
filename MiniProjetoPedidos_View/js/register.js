$('#formRegister').on('submit', function (e) {
  e.preventDefault();

  const username = $('#username').val();
  const password = $('#password').val();

  $.ajax({
    url: `${API_URL}/auth/register`,
    method: 'POST',
    contentType: 'application/json',
    data: JSON.stringify({ username, password }),
    success: function () {
      alert('Usuário registrado com sucesso! Faça login.');
      window.location.href = 'login.html';
    },
    error: function (xhr) {
      alert(xhr.responseText || 'Erro ao registrar usuário.');
    }
  });
});
