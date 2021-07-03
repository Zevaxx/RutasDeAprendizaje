import styled from "styled-components";

export const SeccionPerfilUsuario = styled.section`
  display: flex;
  flex-wrap: wrap;
  flex-direction: column;
  align-items: center;
  font-family: sans-serif;
`;

export const PerfilUsuarioHeader = styled.section`
  width: 100%;
  display: flex;
  justify-content: center;
  margin-bottom: 1.25rem;
`;

export const PerfilUsuarioPortada = styled.section`
  display: block;
  position: relative;
  width: 90%;
  height: 10rem;
  background: linear-gradient(45deg, #b80f22, #000);
  border-radius: 0 0 20px 20px;
`;

export const BotonPortada = styled.button`
  position: absolute;
  top: 1rem;
  right: 1rem;
  border: 0;
  border-radius: 8px;
  padding: 12px 25px;
  background-color: rgba(0, 0, 0, 0.5);
  color: #fff;
  cursor: pointer;
`;
