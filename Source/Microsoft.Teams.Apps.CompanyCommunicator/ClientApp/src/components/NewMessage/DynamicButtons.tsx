import * as React from "react";
import { RouteComponentProps } from "react-router-dom";
import { Input } from "msteams-ui-components-react";
import { Dropdown } from "@stardust-ui/react";

export interface IDynamicButtonsProps extends RouteComponentProps {
  id: number;
  buttonTitle: string;
  buttonUrl: string;
  onButtonTitleChanged: (id: number, vlaue: string) => void;
  onButtonLinkChanged: (id: number, value: string) => void;
}

export default class DynamicButtons extends React.Component<
  IDynamicButtonsProps
> {
  public _onTitleChanged = (event: any): void => {
    this.props.onButtonTitleChanged(this.props.id, event.target.value);
  };
  public _onBtnLinkChanged = (event: any): void => {
    this.props.onButtonLinkChanged(this.props.id, event.target.value);
  };
  public render(): JSX.Element {
    return (
      <>
        <Input
          className="inputField"
          value={this.props.buttonTitle}
          label="Title"
          placeholder="Title (required)"
          onChange={this._onTitleChanged}
          autoComplete="off"
          required
        />
        <Input
          className="inputField"
          value={this.props.buttonUrl}
          label="Button URL"
          placeholder="Button URL"
          onChange={this._onBtnLinkChanged}
          autoComplete="off"
        />
        <Dropdown items={["item 1", "item2", "item3"]} />
      </>
    );
  }
}
