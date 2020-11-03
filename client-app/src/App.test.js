import React from 'react';
import Adapter from '@wojtekmaj/enzyme-adapter-react-17';
import { shallow, configure } from "enzyme";
import App from './App';
import Letra from "./components/letra/Letra";
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
  });

  it("se muestra la imagen con 5 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 5 })
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con5intentos);
  });

  it("se muestra la imagen con 4 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 4 })
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con4intentos);
  });

  it("se muestra la imagen con 3 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 3 })
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con3intentos);
  });

  it("se muestra la imagen con 2 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 2 })
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con2intentos);
  });

  it("se muestra la imagen con 1 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 1 })
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con1intentos);
  });

  it("se muestra la imagen con 0 intentos pendientes", () => {
    const wrapper = shallow(<App />);
    wrapper.setState({ loading: false, cantIntentos: 0 })
    const img = wrapper.find('Image');
    expect(img.prop("src")).toEqual(con0intentos);
  });
 });

 describe("Letra", () => {
  it("update state on click", () => {
      const wrapper = shallow(<Letra />);
      const button = wrapper.find('Button');
      button.simulate("click");
      const habilitado = wrapper.state().habilitado;
      expect(habilitado).toBeFalsy();
  });

  it("boton esta habilitado si la letra no fue ingresada todavia", () => {
    let letrasIngresadas = [];
    const wrapper = shallow(<Letra letra={'a'} habilitado={letrasIngresadas.filter(x => x.letra === letra).length <= 0} />);
    expect(wrapper.state().habilitado).toBeTruthy();
  });

  it("boton deshabilitado si la letra ya fue ingresada", () => {
    let letraDelBoton = 'a';
    let letrasIngresadas = [{ letra: 'a' }]
    const wrapper = shallow(<Letra letra={letraDelBoton} habilitado={letrasIngresadas.filter(x => x.letra === letraDelBoton).length <= 0} />);
    expect(wrapper.state().habilitado).toBeFalsy();
  });
});