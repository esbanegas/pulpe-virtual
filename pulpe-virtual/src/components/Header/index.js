import React, { useState } from "react";
import {
  ActionButton,
  DefaultButton,
  Icon,
  Modal,
  PrimaryButton,
  SearchBox,
} from "@fluentui/react";
import styled from "styled-components";

const HeaderStyled = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;

  padding-top: 2rem;
  padding-bottom: 2rem;
  padding-left: 4rem;
  padding-right: 4rem;

  border-bottom: 2px solid gray;

  .logo {
    .pd5 {
      padding: 5px;
    }

    .border {
      border: 1px solid black;
    }

    .color {
      color: green;
    }
  }
`;

export const Header = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  const handleDismissModal = () => setIsModalOpen(false);

  const handleModalOpen = () => setIsModalOpen(!isModalOpen);

  return (
    <HeaderStyled>
      <SearchBox placeholder="Search" />
      <div className="logo">
        <strong className="border pd5">PULPE</strong>
        <strong className="color pd5">VIRTUAL</strong>
      </div>
      <ActionButton iconProps={{ iconName: "Add" }} onClick={handleModalOpen}>
        {" "}
        Entrar{" "}
      </ActionButton>

      <Modal
        titleAriaId="Identificate"
        isOpen={isModalOpen}
        onDismiss={handleDismissModal}
        isBlocking={false}
      >
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            flexWrap: "wrap",
            padding: 10,
            height: 140,
            alignItems: "center",
          }}
        >
          <div
            style={{
              display: "flex",
              flexDirection: "column",
            }}
          >
            <strong>Identifiquese</strong>
            <span>
              Use su perfil para hacer pedidos en los comercios asociadas a
              Kyte:
            </span>
          </div>

          <div style={{ marginTop: 10 }}>
            <ActionButton
              iconProps={{ iconName: "SemiboldWeight" }}
              onClick={handleModalOpen}
            >
              Google
            </ActionButton>

            <ActionButton
              iconProps={{ iconName: "SkypeLogo16" }}
              onClick={handleModalOpen}
            >
              Facebook
            </ActionButton>
          </div>
        </div>
      </Modal>
    </HeaderStyled>
  );
};
