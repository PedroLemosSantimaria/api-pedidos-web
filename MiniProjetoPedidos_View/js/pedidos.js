let pedidos = [];
let indiceAtual = 0;

function adicionarItem() {
  const linha = `
    <tr>
      <td><input class="form-control codigo"></td>
      <td><input class="form-control descricao"></td>
      <td><input type="number" class="form-control quantidade"></td>
      <td><input type="number" step="0.01" class="form-control valor"></td>
      <td><button type="button" class="btn btn-danger btn-sm" onclick="$(this).closest('tr').remove()">Remover</button></td>
    </tr>`;
  $('#tabelaItens tbody').append(linha);
}

$('#formPedido').on('submit', function (e) {
  e.preventDefault();

  const itens = [];
  $('#tabelaItens tbody tr').each(function () {
    itens.push({
      codigoProduto: $(this).find('.codigo').val(),
      descricaoProduto: $(this).find('.descricao').val(),
      quantidade: parseInt($(this).find('.quantidade').val()),
      valorProduto: parseFloat($(this).find('.valor').val())
    });
  });

  const pedido = {
    numeroPedido: $('#numeroPedido').val(),
    dataSolicitacao: $('#dataSolicitacao').val(),
    dataEntrega: $('#dataEntrega').val(),
    observacao: $('#observacao').val(),
    itens: itens
  };

  $.ajax({
    url: `${API_URL}/pedido`,
    method: 'POST',
    contentType: 'application/json',
    data: JSON.stringify(pedido),
    headers: {
      Authorization: `Bearer ${localStorage.getItem('token')}`
    },
    success: function () {
      alert('Pedido salvo com sucesso!');
      $('#formPedido')[0].reset();
      $('#tabelaItens tbody').empty();
    },
    error: function (xhr) {
      if (xhr.status === 401) logout();
      else alert('Erro ao salvar pedido.');
    }
  });
});

function carregarPedidos() {
  $.ajax({
    url: `${API_URL}/pedido`,
    method: 'GET',
    headers: {
      Authorization: `Bearer ${localStorage.getItem('token')}`
    },
    success: function (data) {
      if (!data || data.length === 0) {
        alert('Nenhum pedido encontrado.');
        return;
      }

      pedidos = data;
      indiceAtual = 0;

      atualizarVisualizacao();
      atualizarControles();
    },
    error: function (xhr) {
      if (xhr.status === 401) logout();
      else alert('Erro ao carregar pedidos.');
    }
  });
}

function atualizarVisualizacao() {
  const pedido = pedidos[indiceAtual];

  $('#numeroPedido').val(pedido.numeroPedido);
  $('#dataSolicitacao').val(pedido.dataSolicitacao.split("T")[0]);
  $('#dataEntrega').val(pedido.dataEntrega.split("T")[0]);
  $('#observacao').val(pedido.observacao);

  $('#tabelaItens tbody').empty();

  pedido.itens.forEach(item => {
    const linha = `
      <tr>
        <td><input class="form-control codigo" value="${item.codigoProduto}"></td>
        <td><input class="form-control descricao" value="${item.descricaoProduto}"></td>
        <td><input type="number" class="form-control quantidade" value="${item.quantidade}"></td>
        <td><input type="number" step="0.01" class="form-control valor" value="${item.valorProduto}"></td>
        <td><button type="button" class="btn btn-danger btn-sm" onclick="$(this).closest('tr').remove()">Remover</button></td>
      </tr>`;
    $('#tabelaItens tbody').append(linha);
  });

  $('#indicePedido').text(`${indiceAtual + 1} / ${pedidos.length}`);
}

function atualizarControles() {
  $('#btnAnterior').prop('disabled', indiceAtual === 0);
  $('#btnProximo').prop('disabled', indiceAtual >= pedidos.length - 1);
}

function logout() {
  localStorage.removeItem('token');
  window.location.href = 'login.html';
}


$('#btnAnterior').click(() => {
  if (indiceAtual > 0) {
    indiceAtual--;
    atualizarVisualizacao();
    atualizarControles();
  }
});

$('#btnProximo').click(() => {
  if (indiceAtual < pedidos.length - 1) {
    indiceAtual++;
    atualizarVisualizacao();
    atualizarControles();
  }
});

$('#btnLogout').click(() => {
  logout();
});


// Verifica token ao abrir página
if (!localStorage.getItem('token')) {
  window.location.href = 'login.html';
}




