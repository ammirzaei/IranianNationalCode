const checked = (codex = "") => {
  let code = codex === "" ? document.getElementById("txtcheck").value : codex;
  if (/^\d{10}$/.test(code) && /^(\d)(?!\1+$)\d{9}$/.test(code)) {
    const contor = code[9];
    let res = Getres(code);
    return res <= 2 ? res == contor : 11 - res == contor;
  }
  return false;
};
const builded = () => {
  let codecity = document.getElementById("codecity").value;
  let codeB = codecity + (Math.random() * 1000000).toFixed(0);
  let res = Getres(codeB);
  let code = res <= 2 ? codeB + res : codeB + (11 - res);
  document.getElementById("parbuild").innerHTML = checked(code)
    ? code
    : "دوباره تلاش کن";
};
const Getres = (code) => {
  let sum = 0;
  for (let i = 0; i < 9; i++) sum += (10 - i) * code[i];
  return sum % 11;
};