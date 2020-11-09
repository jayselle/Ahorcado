import React from 'react';
import Adapter from '@wojtekmaj/enzyme-adapter-react-17';
import { shallow, configure } from "enzyme";
import App from './App';
import Letra from "./components/letra/Letra";
import Tablero from "./components/tablero/Tablero";
import ResultModal from "./components/modal/ResultModal";
import con0intentos from "./images/con0intentos.png";
import con1intentos from "./images/con1intentos.png";
import con2intentos from "./images/con2intentos.png";
import con3intentos from "./images/con3intentos.png";
import con4intentos from "./images/con4intentos.png";
import con5intentos from "./images/con5intentos.png";
import con6intentos from "./images/con6intentos.png";

configure({ adapter: new Adapter() });

describe("Image", () => {
  it("se muestra la imagen con 6 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false });
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con6intentos);
    wrapper.unmount();
  });

  it("se muestra la imagen con 5 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 5 });
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con5intentos);
    wrapper.unmount();
  });

  it("se muestra la imagen con 4 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 4 });
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con4intentos);
    wrapper.unmount();
  });

  it("se muestra la imagen con 3 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 3 });
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con3intentos);
    wrapper.unmount();
  });

  it("se muestra la imagen con 2 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 2 });
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con2intentos);
    wrapper.unmount();
  });

  it("se muestra la imagen con 1 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 1 });
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con1intentos);
    wrapper.unmount();
  });

  it("se muestra la imagen con 0 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 0 });
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con0intentos);
    wrapper.unmount();
  });
});

describe("Letra", () => {
  it("el boton esta habilitado si la letra no fue ingresada todavia", () => {
    let letraDelBoton = 'b';
    let letrasIngresadas = [{ letra: 'a' }]
    const wrapper = shallow(<Letra letra={letraDelBoton} deshabilitada={letrasIngresadas.filter(x => x.letra === letraDelBoton).length > 0} />);
    const button = wrapper.find('Button');
    expect(button.prop("disabled")).toBeFalsy();
    wrapper.unmount();
  });

  it("el boton no esta habilitado si la letra ya fue ingresada", () => {
    let letraDelBoton = 'a';
    let letrasIngresadas = [{ letra: 'a' }]
    const wrapper = shallow(<Letra letra={letraDelBoton} deshabilitada={letrasIngresadas.filter(x => x.letra === letraDelBoton).length > 0} />);
    const button = wrapper.find('Button');
    expect(button.prop("disabled")).toBeTruthy();
    wrapper.unmount();
  });
});

describe("Tablero", () => {
  it("deshabilitar el tablero deshabilita todos los botones", () => {
    const cantIntentos = 0;
    const letrasIngresadas = [];
    const wrapper = shallow(<Tablero letrasIngresadas={letrasIngresadas} disabled={cantIntentos === 0} />);
    const letras = wrapper.find('Letra');
    letras.forEach(x => expect(x.prop("deshabilitada")).toBeTruthy());
    wrapper.unmount();
  });
});

describe("CustomModal", () => {
  it("mensaje de juego ganado en el modal", () => {
    const wrapper = shallow(<ResultModal />);
    const instance = wrapper.instance();
    const juego = { win: true };
    const params = { juego: juego };
    instance.open(params);
    expect(wrapper.text().includes('¡Ganaste!')).toBeTruthy();
    wrapper.unmount();
  });

  it("mensaje de juego perdido en el modal", () => {
    const wrapper = shallow(<ResultModal />);
    const instance = wrapper.instance();
    const juego = { win: false };
    const params = { juego: juego };
    instance.open(params);
    expect(wrapper.text().includes('¡Perdiste!')).toBeTruthy();
    wrapper.unmount();
  });
});